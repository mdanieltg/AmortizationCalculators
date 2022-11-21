namespace AmortizationTableGenerator.BusinessLogicTests;

public class AmortizationCalculatorTests
{
    // [Fact]
    // public void GetValue_ThrowsOutOfRangeException_WhenInvalidFrequencyValue()
    // {
    //     // Prepare
    //     Func<object> minusOne = () => GetValue((Frequency)(-1));
    //     Func<object> eight = () => GetValue((Frequency)8);
    //
    //     // Assert
    //     Assert.Throws<ArgumentOutOfRangeException>(minusOne);
    //     Assert.Throws<ArgumentOutOfRangeException>(eight);
    // }
    //
    // [Fact]
    // public void GetValue_Success_WhenValidFrequencyValue()
    // {
    //     // Prepare
    //     var weekly = GetValue(Frequency.Weekly);
    //     var biweekly = GetValue(Frequency.Biweekly);
    //     var monthly = GetValue(Frequency.Monthly);
    //     var bimonthly = GetValue(Frequency.Bimonthly);
    //     var quarterly = GetValue(Frequency.Quarterly);
    //     var quadrimestral = GetValue(Frequency.Quadrimestral);
    //     var biannual = GetValue(Frequency.Biannual);
    //     var annual = GetValue(Frequency.Annual);
    //
    //     // Assert
    //     Assert.Equal(52, weekly);
    //     Assert.Equal(24, biweekly);
    //     Assert.Equal(12, monthly);
    //     Assert.Equal(6, bimonthly);
    //     Assert.Equal(4, quarterly);
    //     Assert.Equal(3, quadrimestral);
    //     Assert.Equal(2, biannual);
    //     Assert.Equal(1, annual);
    // }
    //
    // [Fact]
    // public void GetEMI_Success_WhenInterestIsNotZero()
    // {
    //     // Prepare
    //     var infoA = new
    //     {
    //         Principal = 100_000d,
    //         Rate = 0.41d,
    //         Terms = 72
    //     };
    //     var infoB = new
    //     {
    //         Principal = 6_700d,
    //         Rate = 0.34d,
    //         Terms = 12,
    //         Frequency = Frequency.Bimonthly
    //     };
    //     var infoC = new
    //     {
    //         Principal = 981_000d,
    //         Rate = 0.69d,
    //         Terms = 18,
    //         Frequency = Frequency.Quarterly
    //     };
    //     var infoD = new
    //     {
    //         Principal = 2_586_000d,
    //         Rate = 0.33d,
    //         Terms = 10,
    //         Frequency = Frequency.Biannual
    //     };
    //
    //     // Act
    //     var emiA = GetEquatedMonthlyInstallment(infoA.Principal, infoA.Rate, infoA.Terms);
    //     var emiB = GetEquatedMonthlyInstallment(infoB.Principal, infoB.Rate, infoB.Terms, infoB.Frequency);
    //     var emiC = GetEquatedMonthlyInstallment(infoC.Principal, infoC.Rate, infoC.Terms, infoC.Frequency);
    //     var emiD = GetEquatedMonthlyInstallment(infoD.Principal, infoD.Rate, infoD.Terms, infoD.Frequency);
    //
    //     // Assert
    //     Assert.Equal(3_750.53452, emiA, 3);
    //     Assert.Equal(784.6167, emiB, 3);
    //     Assert.Equal(179_453.563, emiC, 3);
    //     Assert.Equal(545_040.2994, emiD, 3);
    // }
    //
    // [Fact]
    // public void GetEMI_Success_WhenInterestIsZero()
    // {
    //     // Prepare
    //     var infoA = new
    //     {
    //         Principal = 1_200d,
    //         Terms = 4,
    //         Frequency = Frequency.Quarterly
    //     };
    //     var infoB = new
    //     {
    //         Principal = 75_400d,
    //         Terms = 70,
    //         Frequency = Frequency.Biweekly
    //     };
    //     var infoC = new
    //     {
    //         Principal = 958_000d,
    //         Terms = 36
    //     };
    //
    //     // Act
    //     var emiA = GetEquatedMonthlyInstallment(infoA.Principal, 0, infoA.Terms, infoA.Frequency);
    //     var emiB = GetEquatedMonthlyInstallment(infoB.Principal, 0, infoB.Terms, infoB.Frequency);
    //     var emiC = GetEquatedMonthlyInstallment(infoC.Principal, 0, infoC.Terms);
    //
    //     // Assert
    //     Assert.Equal(300, emiA, 3);
    //     Assert.Equal(1_077.1428, emiB, 3);
    //     Assert.Equal(26_611.1111, emiC, 3);
    // }
    //
    // [Fact]
    // public void GetEMI_ThrowsArgumentException_WhenInterestIsLowerThanZero()
    // {
    //     Assert.Throws<ArgumentException>(() => GetEquatedMonthlyInstallment(1_000, -2, 8, Frequency.Weekly));
    // }
    //
    // [Fact]
    // public void GetEMI_ThrowsArgumentException_WhenTermsIsEqualToOrLowerThanZero()
    // {
    //     Assert.Throws<ArgumentException>(() => GetEquatedMonthlyInstallment(1_000, 2, 0, Frequency.Bimonthly));
    // }
}
