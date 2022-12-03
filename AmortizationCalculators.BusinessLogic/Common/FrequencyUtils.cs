namespace AmortizationCalculators.BusinessLogic.Common;

public static class FrequencyUtils
{
    internal static double GetValue(this Frequency frequency)
    {
        return frequency switch
        {
            Frequency.Monthly => 1,
            Frequency.Bimonthly => 2,
            Frequency.Quarterly => 3,
            Frequency.Quadrimestral => 4,
            Frequency.Biannual => 6,
            Frequency.Annual => 12,
            _ => throw new ArgumentOutOfRangeException(nameof(frequency), frequency, null)
        };
    }

    public static string Word(this Frequency frequency)
    {
        return frequency switch
        {
            Frequency.Monthly => "Monthly",
            Frequency.Bimonthly => "Bimonthly",
            Frequency.Quarterly => "Quarterly",
            Frequency.Quadrimestral => "Quadrimestral",
            Frequency.Biannual => "Biannual",
            Frequency.Annual => "Annual",
            _ => throw new ArgumentOutOfRangeException(nameof(frequency), frequency, null)
        };
    }
}
