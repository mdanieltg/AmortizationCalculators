namespace AmortizationTableGenerator.BusinessLogicTests.Estimation;

public class InstallmentTests
{
    // [Fact]
    // public void Constructor_ThrowsError_WhenParametersAreInvalid()
    // {
    //     // Prepare
    //     var invalidInstallmentNumber = () =>
    //     {
    //         new Installment(0, 1, 0, 0, 0);
    //         new Installment(-1, 1, 0, 0, 0);
    //     };
    //     var invalidPrincipal = () =>
    //     {
    //         new Installment(1, 0, 0, 0, 0);
    //         new Installment(1, -1, 0, 0, 0);
    //     };
    //     var invalidRate = () => { new Installment(1, 1, -1, 0, 0); };
    //     var invalidPayment = () => { new Installment(1, 1, 0, -1, 0); };
    //     var invalidAdvance = () =>
    //     {
    //         new Installment(1, 1, 0, 0, 1);
    //         new Installment(1, 1, 0, 0, -1);
    //     };
    //
    //     // Assert
    //     Assert.Throws<ArgumentException>("installmentNumber", invalidInstallmentNumber);
    //     Assert.Throws<ArgumentException>("principal", invalidPrincipal);
    //     Assert.Throws<ArgumentException>("rate", invalidRate);
    //     Assert.Throws<ArgumentException>("payment", invalidPayment);
    //     Assert.Throws<ArgumentException>("advance", invalidAdvance);
    // }
    //
    // [Fact]
    // public void PropertyDate_IsNull_WhenDateIsNotSet()
    // {
    //     var i = new Installment(1, 1000, 0.012, 100, 0);
    //
    //     Assert.Equal(1, i.InstallmentNumber);
    //     Assert.Null(i.PaymentDate);
    //     Assert.Equal(1000, i.Principal);
    //     Assert.Equal(100, i.Payment);
    //     Assert.Equal(0, i.Advance);
    //     Assert.Equal(12, i.InterestPayment);
    //     Assert.Equal(88, i.PrincipalPayment);
    //     Assert.Equal(912, i.NewPrincipal);
    // }
    //
    // [Fact]
    // public void PropertyDate_IsNotNull_WhenDateIsSet()
    // {
    //     var i = new Installment(1, 1000, 0.012, 100, 0, new DateTime(2022, 5, 29));
    //
    //     Assert.Equal(1, i.InstallmentNumber);
    //     Assert.Equal(new DateTime(2022, 5, 29), i.PaymentDate);
    //     Assert.Equal(1000, i.Principal);
    //     Assert.Equal(100, i.Payment);
    //     Assert.Equal(0, i.Advance);
    //     Assert.Equal(12, i.InterestPayment);
    //     Assert.Equal(88, i.PrincipalPayment);
    //     Assert.Equal(912, i.NewPrincipal);
    // }
    //
    // [Fact]
    // public void GetLine_WhenPaymentDateIsNull()
    // {
    //     var i = new Installment(1, 1000, 0.012, 100, 0);
    //     var line = "   1 |    $1,000.00 |      $100.00 |       $88.00 |       $12.00 |       $912.00";
    //
    //     Assert.Equal(line, i.GetLine());
    // }
    //
    // [Fact]
    // public void GetLine_WhenPaymentDateIsNotNull()
    // {
    //     var i = new Installment(1, 1000, 0.012, 100, 0, new DateTime(2022, 5, 29));
    //     var line = "   1 | 2022-05-29   |    $1,000.00 |      $100.00 |       $88.00 |       $12.00 |       $912.00";
    //
    //     Assert.Equal(line, i.GetLine());
    // }
}
