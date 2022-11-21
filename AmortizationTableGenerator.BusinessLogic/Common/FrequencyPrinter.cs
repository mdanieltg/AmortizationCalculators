namespace AmortizationTableGenerator.BusinessLogic.Common;

public static class FrequencyPrinter
{
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

    public static string Period(this Frequency frequency)
    {
        return frequency switch
        {
            Frequency.Monthly => "Months",
            Frequency.Bimonthly => "Months",
            Frequency.Quarterly => "Months",
            Frequency.Quadrimestral => "Months",
            Frequency.Biannual => "Months",
            Frequency.Annual => "Years",
            _ => throw new ArgumentOutOfRangeException(nameof(frequency), frequency, null)
        };
    }
}
