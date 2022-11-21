namespace AmortizationTableGenerator.BusinessLogic.Common;

public class InstallmentPrinter
{
    private static readonly string Template =
        " {0,3} | {1,12:C} | {2,12:C} | {3,12:C} | {4,12:C} | {5,13:C}";
    // " {0,3} | {1,-12:yyyy-MM-dd} | {2,12:C} | {3,12:C} | {4,12:C} | {5,12:C} | {6,13:C}";

    public static string Write(Installment installment)
    {
        return string.Format(Template,
            installment.InstallmentNumber,
            installment.Principal,
            installment.Payment,
            installment.PrincipalPayment,
            installment.InterestPayment,
            installment.NewPrincipal);
    }
}
