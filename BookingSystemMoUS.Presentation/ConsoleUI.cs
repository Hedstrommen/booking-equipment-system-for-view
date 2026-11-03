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
                EquipmentModel? selectedModel = SelectModel();

                //Välj period
                HirePeriod selectedPeriod = SelectPeriod();

                //Visa pris
                PriceResultRecord priceResult = await ShowFinalPriceAsync(selectedModel, selectedPeriod);

                DisplayPriceResult(priceResult);

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

    private EquipmentModel? SelectModel()
    {
        Console.WriteLine("Välj utrustning genom att skriva berört namn");
        string? selectedModelName = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(selectedModelName))
        {
            throw new ArgumentException("Inget namn angavs för utrustningen.");
        }

        return equipmentModelRepository.GetByNameAsync(selectedModelName).Result;
    }

    
}
