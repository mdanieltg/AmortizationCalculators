namespace AmortizationTableGenerator.BusinessLogic;

public class Installment
{
    private static readonly string WithoutDateTemplate = @" {0,3} | {1,12:C} | {2,12:C} | {3,12:C} | {4,12:C} | {5,13:C}",
        WithDateTemplate = @" {0,3} | {1,-12:yyyy-MM-dd} | {2,12:C} | {3,12:C} | {4,12:C} | {5,12:C} | {6,13:C}";

    public Installment(int installmentNumber, double principal, double rate, double payment, double advance,
        DateTime? paymentDate = null)
    {
        InstallmentNumber = installmentNumber;
        PaymentDate = paymentDate;
        Principal = principal;
        Advance = advance;
        Payment = payment + Advance;
        InterestPayment = Principal * rate;
        PrincipalPayment = Payment - InterestPayment;
        NewPrincipal = Principal - PrincipalPayment;
    }

    public int InstallmentNumber { get; }
    public DateTime? PaymentDate { get; }
    public double Principal { get; }
    public double Advance { get; }
    public double Payment { get; }
    public double PrincipalPayment { get; }
    public double InterestPayment { get; }
    public double NewPrincipal { get; }

    public string GetLine()
    {
        if (PaymentDate is null)
        {
            return string.Format(WithoutDateTemplate,
                InstallmentNumber,
                Principal,
                Payment,
                PrincipalPayment,
                InterestPayment,
                NewPrincipal);
        }
        else
        {
            return string.Format(WithDateTemplate,
                InstallmentNumber,
                PaymentDate,
                Principal,
                Payment,
                PrincipalPayment,
                InterestPayment,
                NewPrincipal);
        }
    }
}
