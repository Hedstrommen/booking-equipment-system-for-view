namespace BookingSystemMoUS.Domain.ValueObjects;
//Skriver med Pascal på Start/EndDate då de blir properties och inte vanliga variabler i en record.
public record HirePeriod
{
    public DateOnly StartDate { get; }
    public DateOnly EndDate { get; }

    private HirePeriod(DateOnly startDate, DateOnly endDate)
    {
        StartDate = startDate;
        EndDate = endDate;
    }

    public static HirePeriod ValidateHirePeriod(DateOnly startDate, DateOnly endDate)
    {
        if (endDate < startDate)
        {
            throw new ArgumentException("Slutdatumet måste vara efter startdatumet.");
        }
        else if (endDate > startDate.AddYears(1))
        {
            throw new ArgumentException("Du kan inte hyra mer än ett år åt gången");
        }
        else if (startDate > DateOnly.FromDateTime(DateTime.Today).AddYears(5) )
        {
            throw new ArgumentException("Du kan inte boka en hyrperiod längre fram än 5 år");
        }
        return new HirePeriod(startDate, endDate);
    }

    public int GetRentalDays()
    {
        return EndDate.DayNumber - StartDate.DayNumber + 1;
    }
}
