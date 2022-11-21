namespace AmortizationCalculators.BusinessLogicTests.Estimation;

public class InstallmentsCalculatorTests
{
    // [Fact]
    // public void EmptyCalculator_ShouldBeEmpty()
    // {
    //     Assert.Equal(0, Empty.Interest);
    //     Assert.Equal(0, Empty.Total);
    //     Assert.Equal(0, Empty.Terms);
    //     Assert.Null(Empty.GetInstallment(1));
    // }
    //
    // [Fact]
    // public void GetInstallment_ThrowsArgumentException_WhenNumberIsEqualToOrGreaterThanZero()
    // {
    //     // Prepare
    //     var calculator = new InstallmentsCalculator(699,
    //         0.15,
    //         121.65,
    //         6,
    //         0,
    //         Frequency.Monthly, null);
    //
    //     // Act and assert
    //     Assert.Throws<ArgumentException>(() => calculator.GetInstallment(-1));
    //     Assert.Throws<ArgumentException>(() => Empty.GetInstallment(0));
    // }
    //
    // [Fact]
    // public void GetInstallment_ShouldReturnNull_WhenInstallmentNumberDoesNotExist()
    // {
    //     // Prepare
    //     var calculator = new InstallmentsCalculator(699,
    //         0.15,
    //         121.65,
    //         6,
    //         0,
    //         Frequency.Monthly, null);
    //
    //     // Act
    //     var installment = calculator.GetInstallment(7);
    //
    //     // Assert
    //     Assert.Null(installment);
    // }
    //
    // [Fact]
    // public void GetInstallment_ShouldNotReturnNull_WhenInstallmentNumberDoesExist()
    // {
    //     // Prepare
    //     var calculator = new InstallmentsCalculator(699,
    //         0.15,
    //         121.65,
    //         6,
    //         0,
    //         Frequency.Monthly, new DateTime(2022, 1, 1));
    //
    //     // Act
    //     var installment = calculator.GetInstallment(1);
    //
    //     // Assert
    //     Assert.NotNull(installment);
    // }
    //
    // [Fact]
    // public void Constructor_ThrowsError_WhenParametersAreInvalid()
    // {
    //     // Prepare
    //     var invalidRate = () => { new InstallmentsCalculator(1, -1, 1, 1, 0, Frequency.Weekly); };
    //     var invalidPrincipal = () => { new InstallmentsCalculator(0, 1, 1, 0, 0, Frequency.Biweekly); };
    //     var invalidPayment = () => { new InstallmentsCalculator(1, 1, -1, -1, 0, Frequency.Bimonthly); };
    //     var invalidTerms = () => { new InstallmentsCalculator(1, 1, 1, 0, 0, Frequency.Quarterly); };
    //     var invalidAdvance = () => { new InstallmentsCalculator(1, 1, 1, 1, -1, Frequency.Quadrimestral); };
    //     var invalidFrequency = () => { new InstallmentsCalculator(1, 1, 1, 1, 0, (Frequency)12); };
    //
    //     // Assert
    //     Assert.Throws<ArgumentException>("principal", invalidPrincipal);
    //     Assert.Throws<ArgumentException>("rate", invalidRate);
    //     Assert.Throws<ArgumentException>("payment", invalidPayment);
    //     Assert.Throws<ArgumentException>("terms", invalidTerms);
    //     Assert.Throws<ArgumentException>("advance", invalidAdvance);
    //     Assert.Throws<ArgumentOutOfRangeException>("paymentFrequency", invalidFrequency);
    // }
}
