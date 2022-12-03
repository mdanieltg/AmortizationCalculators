using System.Text;
using AmortizationCalculators.BusinessLogic.Common;

namespace AmortizationCalculators.BusinessLogic.Estimations.Simple;

public class Printer : IPrinter
{
    private readonly AmortizedLoanEstimate _estimate;

    public Printer(AmortizedLoanEstimate estimate)
    {
        _estimate = estimate;
    }

    public string GetInformation()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"Estimation date: {_estimate.EstimationDate:D}");
        sb.AppendLine();

        sb.Append($"Principal: {_estimate.Principal,12:C}");
        sb.AppendLine($"         Rate: {_estimate.InterestRate,8:P} {_estimate.RateType.Word().ToLowerInvariant()}");
        sb.Append($" Interest: {_estimate.TotalInterest,12:C}");
        sb.AppendLine($"        Terms: {_estimate.Terms,6:N0} ({_estimate.PaymentFrequency.Word().ToLowerInvariant()})");
        sb.Append($"    Total: {_estimate.Total,12:C}");
        sb.Append($"  Installment: {_estimate.EquatedMonthlyInstallment,12:C}");

        return sb.ToString();
    }

    public string GetTable()
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.AppendLine($@" {"#",-3} | {"Principal",-12} | {"Payment",-12} | {"To Principal",-12} | {"To Interest",-12} | {"New Principal",-13}");
        stringBuilder.AppendLine(" --- | ------------ | ------------ | ------------ | ------------ | ------------- ");

        var i = 1;
        while (i <= _estimate.Terms)
        {
            var installment = _estimate.GetInstallment(i);
            var line = string.Format(" {0,3} | {1,12:C} | {2,12:C} | {3,12:C} | {4,12:C} | {5,13:C}",
                installment.InstallmentNumber,
                installment.Principal,
                installment.Payment,
                installment.PrincipalPayment,
                installment.InterestPayment,
                installment.NewPrincipal);

            stringBuilder.AppendFormat(line);
            stringBuilder.AppendLine();
            ++i;
        }

        return stringBuilder.ToString();
    }

    public void PrintEstimate(TextWriter output)
    {
        output.WriteLine(GetInformation());
        output.WriteLine();
        output.WriteLine(GetTable());
    } 
}
