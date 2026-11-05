
namespace BookingSystemMoUS.Domain.ValueObjects;
//ValueObject = representerar värdet på objektets pris och dess validering
//Record = Inbyggd funktionalitet för att kunna jämföra värden
//Struct = oföränderliga värden och mindre minnesanvändning

public readonly record struct DailyPrice(decimal priceValue)
{
    //"FromDecimal" då jag förstått att det är namngivningskonvention
    public static DailyPrice FromDecimal(decimal priceValue)
    {
        if (priceValue <= 0)
        {
            throw new ArgumentException("Dagspriset måste vara större än noll");
        }
        return new DailyPrice(Math.Round(priceValue, 2));
    }
}
