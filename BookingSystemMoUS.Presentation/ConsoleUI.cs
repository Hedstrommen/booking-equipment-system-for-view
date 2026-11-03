using BookingSystemMoUS.Application.Dtos;
using BookingSystemMoUS.Application.Interfaces;
using BookingSystemMoUS.Application.Services;
using BookingSystemMoUS.Domain.Models;
using BookingSystemMoUS.Domain.ValueObjects;

namespace BookingSystemMoUS.Presentation;
public class ConsoleUI(IEquipmentModelRepository equipmentModelRepository)
{
    public async Task RunProgramAsync(CalculateTotalPriceService calculateTotalPriceService)
    {
        bool bookingInProgress = true;
        while (bookingInProgress)
        {
            try
            {
                //Skriva ut alla tillgängliga modeller + pris
                await PrintAllModelsAsync();

                //Välj modell
                EquipmentModel? selectedModel = await SelectModelAsync();

                //Välj period
                HirePeriod selectedPeriod = SelectPeriod();

                //Visa pris
                PriceResultRecord priceResult = await calculateTotalPriceService.CalculateFinalPriceServiceAsync(selectedModel, selectedPeriod);

                DisplayFinalPrice(priceResult);

                //Bekräftelse
                bookingInProgress = ConfirmBooking();
            }
            catch (ArgumentException exception)
            {

            }
        }
    }

    private async Task PrintAllModelsAsync()
    {
        Console.WriteLine("Tillgänglig utrustning:");
        var models = await equipmentModelRepository.GetAllAsync();

        foreach (var model in models)
        {
            Console.WriteLine($"Utrustning: {model.EquipmentName}\tPris per dag: {model.DailyPrice.priceValue} kr)");
        }
    }

    private async Task<EquipmentModel?> SelectModelAsync()
    {
        while (true)
        {
            Console.WriteLine("Välj utrustning genom att skriva berört namn");
            string? selectedModelName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(selectedModelName))
            {
                Console.WriteLine("Ogiltigt namn, försök igen.");
                continue;
            }

            EquipmentModel? model = await equipmentModelRepository.GetByNameAsync(selectedModelName);

            if (model is null)
            {
                Console.WriteLine("Ogiltigt namn, försök igen.");
                continue;
            }
            return model;
        }
    }

    private HirePeriod SelectPeriod()
    {
        while (true)
        {
            DateOnly startDate = ReadDate("Ange startdatum (ÅÅÅÅ-MM-DD): ");
            DateOnly endDate = ReadDate("Ange slutdatum (ÅÅÅÅ-MM-DD): ");

            try
            {
                return HirePeriod.CreateHirePeriod(startDate, endDate);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Ogiltigt datumintervall, säkerställ att slutdatumen är efter startdatumet och försök igen.");
            }
        }
    }

    private DateOnly ReadDate(string promptForInput)
    {
        while (true)
        {
            Console.WriteLine(promptForInput);

            if (DateOnly.TryParse(Console.ReadLine(), out DateOnly inputDate))
                return inputDate;

            Console.WriteLine("Ogiltigt format, försöker igen med formatet ÅÅÅÅ-MM-DD: ");
        }
    }

    private void DisplayFinalPrice(PriceResultRecord priceResult)
    {
        

        //Skriv ut priset i konsolen.

    }
}
