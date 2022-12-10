using System.Text;
using AmortizationCalculators.BusinessLogic.Common;

namespace AmortizationCalculators.BusinessLogic.Estimations.Simple;

public class AmortizedLoanEstimate : IPrintableEstimate
{
    private readonly Dictionary<int, Installment> _installments = new();

    private AmortizedLoanEstimate()
    {
    }

    public double Principal { get; init; }
    public double InterestRate { get; init; }
    public int Terms { get; init; }
    public Frequency PaymentFrequency { get; init; }
    public double EquatedMonthlyInstallment { get; init; }
    public double TotalInterest { get; init; }
    public double Total { get; set; }
    public DateTime EstimationDate { get; init; }

    public static AmortizedLoanEstimate CreateEstimate(double principal, double interestRate, int terms,
        Frequency paymentFrequency)
    {
        // Input validation
        if (!Enum.IsDefined(typeof(Frequency), paymentFrequency)) throw new ArgumentException();
        if (principal <= 0 || interestRate <= 0 || terms <= 0) throw new ArgumentException();

        // Calculate EMI
        var rate = interestRate / 12 * paymentFrequency.GetValue();

        var a = Math.Pow(1 + rate, terms);
        var b = rate * a / (a - 1);
        var emi = principal * b;

        var amortizedLoanEstimate = new AmortizedLoanEstimate
        {
            EstimationDate = DateTime.Now,
            Principal = principal,
            InterestRate = interestRate,
            Terms = terms,
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
        var rate = InterestRate / 12 * PaymentFrequency.GetValue();

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

    public string GetInformation()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"Estimation date: {EstimationDate:D}");
        sb.AppendLine();

        sb.Append($"Principal: {Principal,12:C}");
        sb.AppendLine($"           Rate: {InterestRate,8:P} annual");
        sb.Append($" Interest: {TotalInterest,12:C}");
        sb.AppendLine($"          Terms: {Terms,6:N0}");
        sb.Append($"    Total: {Total,12:C}");
        sb.Append($"    Installment: {EquatedMonthlyInstallment,8:C}");
        sb.Append($" {PaymentFrequency.Word().ToLowerInvariant()}");

        return sb.ToString();
    }

    public string GetTable()
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.AppendLine(
            $@" {"#",-3} | {"Principal",-12} | {"Payment",-12} | {"To Principal",-12} | {"To Interest",-12} | {"New Principal",-13}");
        stringBuilder.AppendLine(" --- | ------------ | ------------ | ------------ | ------------ | ------------- ");

        var i = 1;
        while (i <= Terms)
        {
            var installment = GetInstallment(i);
            var line = string.Format(" {0,3} | {1,12:C} | {2,12:C} | {3,12:C} | {4,12:C} | {5,13:C}",
                installment.InstallmentNumber,
                installment.Principal,
                installment.Payment,
                installment.PrincipalPayment,
                installment.InterestPayment,
                installment.NewPrincipal);

            stringBuilder.AppendFormat(line);

            if (i < Terms)
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
        output.WriteLine();
    }

    public async Task PrintEstimateAsync(TextWriter output)
    {
        await output.WriteLineAsync(GetInformation());
        await output.WriteLineAsync();
        await output.WriteLineAsync(GetTable());
    }
}
