namespace BookingSystemMoUS.Domain.ValueObjects;
//Skriver med Pascal på Start/EndDate då de blir properties och inte vanliga variabler i en record.
public record HirePeriod(DateOnly StartDate, DateOnly EndDate)
{
    public int GetRentalDays()
    {
        return EndDate.DayNumber - StartDate.DayNumber + 1;
    }

    public static HirePeriod CreateHirePeriod(DateOnly startDate, DateOnly endDate)
    {
        if (endDate < startDate)
        {
            throw new ArgumentException("Slutdatumet måste vara efter startdatumet.");
        }
        return new HirePeriod(startDate, endDate);
    }
}
