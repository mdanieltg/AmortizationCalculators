using System.Text;
using AmortizationCalculators.BusinessLogic.Common;

namespace AmortizationCalculators.BusinessLogic;

public class InstallmentsManager
{
    private readonly Dictionary<int, Installment> _installments = new();
    private readonly AmortizedLoanEstimate _estimate;

    private InstallmentsManager(AmortizedLoanEstimate estimate)
    {
        _estimate = estimate;
        Principal = estimate.Principal;
        InterestRate = estimate.InterestRate;
        RateType = estimate.RateType;
        PaymentFrequency = estimate.PaymentFrequency;
        Terms = estimate.Terms;
    }

    public double Principal { get; }
    public double InterestRate { get; }
    public Frequency RateType { get; }
    public Frequency PaymentFrequency { get; }
    public int Terms { get; }

    public string GetTable()
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.AppendLine($@" {"#",-3} | {"Principal",-12} | {"Payment",-12} | {"To Principal",-12} | {"To Interest",-12} | {"New Principal",-13}");
        stringBuilder.AppendLine(" --- | ------------ | ------------ | ------------ | ------------ | ------------- ");
        foreach (var installment in _installments.Values)
        {
            stringBuilder.AppendFormat(InstallmentPrinter.Write(installment));
            stringBuilder.AppendLine();
        }

        return stringBuilder.ToString();
    }

    public void Print(TextWriter o)
    {
        o.WriteLine(_estimate.GetInformation());
        o.WriteLine();
        o.WriteLine(GetTable());
    }

    public static InstallmentsManager GenerateInstallments(AmortizedLoanEstimate amortizedLoanEstimate)
    {
        var manager = new InstallmentsManager(amortizedLoanEstimate);
        var principal = amortizedLoanEstimate.Principal;
        var rate = amortizedLoanEstimate.InterestRate / amortizedLoanEstimate.RateType.GetValue() *
                   amortizedLoanEstimate.PaymentFrequency.GetValue();

        var installmentNumber = 1;
        while (installmentNumber <= amortizedLoanEstimate.Terms)
        {
            var payment = amortizedLoanEstimate.EquatedMonthlyInstallment;
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

            manager._installments.Add(installmentNumber++, installment);
        }

        return manager;
    }
}
