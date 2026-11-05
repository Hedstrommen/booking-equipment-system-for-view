using BookingSystemMoUS.Domain.ValueObjects;

namespace BookingSystemMoUS.Domain.Services;
public class PriceCalculationService
{
    public decimal CalculateTotalPrice(DailyPrice price, HirePeriod period)
    {
        return Math.Round(price.priceValue * period.GetRentalDays(), 2);
    }
}
