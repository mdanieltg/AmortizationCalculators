using System.Text;
using AmortizationCalculators.BusinessLogic.Common;

namespace AmortizationCalculators.BusinessLogic.Estimations.Simple;

public class AmortizedLoanEstimate
{
    private readonly Dictionary<int, Installment> _installments = new();

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

        var amortizedLoanEstimate = new AmortizedLoanEstimate
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
        amortizedLoanEstimate.GenerateInstallments();

        return amortizedLoanEstimate;
    }

    private void GenerateInstallments()
    {
        var principal = Principal;
        var rate = InterestRate / RateType.GetValue() * PaymentFrequency.GetValue();

        var installmentNumber = 1;
        while (installmentNumber <= Terms)
        {
            var payment = EquatedMonthlyInstallment;
            var interestPayment = principal * rate;
            var principalPayment = payment - interestPayment;
            var newPrincipal = principal - principalPayment;

            var installment = new Installment
            {
                Rate = rate,
                InstallmentNumber = installmentNumber,
                Principal = principal,
                Payment = payment,
                PrincipalPayment = principalPayment,
                InterestPayment = interestPayment,
                NewPrincipal = newPrincipal
            };
            principal = newPrincipal;

            _installments.Add(installmentNumber++, installment);
        }
    }

    public Installment GetInstallment(int installmentNumber)
    {
        if (installmentNumber <= 0 || installmentNumber > Terms)
            throw new ArgumentException($"The value must be greater than zero and equal to or less than {Terms}",
                nameof(installmentNumber));

        return _installments[installmentNumber];
    }

}
