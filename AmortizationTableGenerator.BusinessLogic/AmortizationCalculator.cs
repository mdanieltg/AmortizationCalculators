namespace AmortizationTableGenerator.BusinessLogic;

public static class AmortizationCalculator
{
    /// <summary>
    /// Calculates the equated monthly installment (EMI) with the given values.
    /// </summary>
    /// <param name="principal">The amount to lend or borrow.</param>
    /// <param name="interestRate">The annual interest rate percentage.</param>
    /// <param name="terms">The amount of installments in units of <paramref name="frequency"/>.</param>
    /// <param name="frequency">The frequency of the payments. Default is monthly.</param>
    /// <returns>The monthly installment to pay.</returns>
    public static double GetEquatedMonthlyInstallment(double principal, double interestRate, int terms,
        Frequency frequency = Frequency.Monthly)
    {
        if (interestRate < 0) throw new ArgumentException("The interest rate cannot be lower than zero.");
        if (interestRate == 0) return ZeroInterest(principal, terms, frequency);

        var i = interestRate;
        var n = GetValue(frequency);
        var t = terms / n;

        var step = 1 - Math.Pow(1 + i / n, -n * t);
        return i * principal / (n * step);
    }

    private static double ZeroInterest(double principal, int terms, Frequency frequency)
    {
        var n = GetValue(frequency);
        var t = terms / n;
        return principal / (n * t);
    }

    internal static double GetValue(Frequency frequency)
    {
        return frequency switch
        {
            Frequency.Weekly => 52,
            Frequency.Biweekly => 24,
            Frequency.Monthly => 12,
            Frequency.Bimonthly => 6,
            Frequency.Quarterly => 4,
            Frequency.Quadrimestral => 3,
            Frequency.Biannual => 2,
            Frequency.Annual => 1,
            _ => throw new ArgumentOutOfRangeException(nameof(frequency), frequency, null)
        };
    }
}
