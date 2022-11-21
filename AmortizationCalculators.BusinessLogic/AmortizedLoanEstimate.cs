using System.Text;
using AmortizationCalculators.BusinessLogic.Common;

namespace AmortizationCalculators.BusinessLogic;

public class AmortizedLoanEstimate
{
    private AmortizedLoanEstimate()
    {
    }

    public double Principal { get; init; }
    public double InterestRate { get; init; }
    public Frequency RateType { get; init; }
    public int Terms { get; init; }
    public Frequency PaymentFrequency { get; init; }
    public double EquatedMonthlyInstallment { get; init; }
    public double TotalInterest { get; init; }
    public double Total { get; set; }
    public DateTime EstimationDate { get; init; }

    public double AnnualInterestRate => InterestRate * RateType switch
    {
        Frequency.Monthly => 12,
        Frequency.Bimonthly => 6,
        Frequency.Quarterly => 4,
        Frequency.Quadrimestral => 3,
        Frequency.Biannual => 2,
        Frequency.Annual => 1,
        _ => throw new ArgumentOutOfRangeException()
    };

    public static AmortizedLoanEstimate CreateEstimate(double principal, double interestRate, Frequency rateType,
        int terms, Frequency paymentFrequency)
    {
        // Input validation
        if (!Enum.IsDefined(typeof(Frequency), rateType)) throw new ArgumentException();
        if (!Enum.IsDefined(typeof(Frequency), paymentFrequency)) throw new ArgumentException();
        if (principal <= 0 || interestRate <= 0 || terms <= 0) throw new ArgumentException();

        // Calculate EMI
        var rate = interestRate / rateType.GetValue() * paymentFrequency.GetValue();

        var a = Math.Pow(1 + rate, terms);
        var b = rate * a / (a - 1);
        var emi = principal * b;

        return new AmortizedLoanEstimate
        {
            EstimationDate = DateTime.Now,
            Principal = principal,
            InterestRate = interestRate,
            Terms = terms,
            RateType = rateType,
            PaymentFrequency = paymentFrequency,
            EquatedMonthlyInstallment = emi,
            TotalInterest = emi * terms - principal,
            Total = emi * terms
        };
    }

    public string GetInformation()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"Estimation date: {EstimationDate:D}");
        sb.AppendLine();

        sb.Append($"Principal: {Principal,12:C}");
        sb.AppendLine($"         Rate: {InterestRate,8:P} {RateType.Word().ToLowerInvariant()}");
        sb.Append($" Interest: {TotalInterest,12:C}");
        sb.AppendLine($"        Terms: {Terms,6:N0} ({PaymentFrequency.Word().ToLowerInvariant()})");
        sb.Append($"    Total: {Total,12:C}");
        sb.Append($"  Installment: {EquatedMonthlyInstallment,12:C}");

        return sb.ToString();
    }
}
