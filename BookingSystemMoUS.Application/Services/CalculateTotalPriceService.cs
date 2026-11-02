using BookingSystemMoUS.Application.Dtos;
using BookingSystemMoUS.Application.Interfaces;
using BookingSystemMoUS.Domain.Models;
using BookingSystemMoUS.Domain.Services;
using BookingSystemMoUS.Domain.ValueObjects;

namespace BookingSystemMoUS.Application.Services;
public class CalculateTotalPriceService(IEquipmentModelRepository equipmentModelRepository,
    PriceCalculationService priceCalculationService)
{
    public async Task<PriceResultRecord> ShowFinalPriceServiceAsync(string equipmentName, HirePeriod period)
    {
        //Vi hämtar specifik modell genom repository. Om ej finns -> felmeddelande.
        EquipmentModel? model = await equipmentModelRepository.GetByNameAsync(equipmentName)
            ?? throw new InvalidOperationException($"Utrustningsmodellen med namnet '{equipmentName}' finns inte.");

        //Beräknar totalen genom service
        decimal finalPrice = priceCalculationService.CalculateTotalPrice(model.DailyPrice, period);

        //Returnerar resultatet som en PriceResultRecord
        return new PriceResultRecord
        (
            model.EquipmentName,
            model.DailyPrice,
            period.StartDate,
            period.EndDate,
            period.GetRentalDays(),
            finalPrice
        );
    }
}
