namespace AmortizationCalculators.BusinessLogic;

public class Installment
{
    public double Rate { get; set; }
    public int InstallmentNumber { get; set; }
    public DateTime PaymentDate { get; set; }
    public double Principal { get; set; }
    public double Payment { get; set; }
    public double InterestPayment { get; set; }
    public double PrincipalPayment { get; set; }
    public double NewPrincipal { get; set; }
}
