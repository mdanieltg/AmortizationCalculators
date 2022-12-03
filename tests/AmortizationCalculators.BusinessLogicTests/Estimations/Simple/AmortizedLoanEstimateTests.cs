using AmortizationCalculators.BusinessLogic;
using AmortizationCalculators.BusinessLogic.Estimations.Simple;

namespace AmortizationCalculators.BusinessLogicTests.Estimations.Simple;

public class AmortizedLoanEstimateTests
{
    private AmortizedLoanEstimate _estimate;

    [SetUp]
    public void SetUp()
    {
        _estimate = AmortizedLoanEstimate.CreateEstimate(699, 0.15, 6, Frequency.Monthly);
    }

    [TestCase(12_000, 0.025, 12, Frequency.Monthly, 1_013.5933, 163.12)]
    [TestCase(93_125, 0.35, 10, Frequency.Bimonthly, 12_552.9842, 32_404.8418)]
    [TestCase(6_653, 0.685, 6, Frequency.Quarterly, 1_859.6659, 4_504.9951)]
    [TestCase(152_056, 0.892, 20, Frequency.Quadrimestral, 45_460.549, 757_154.9790)]
    [TestCase(5_600_281, 0.317, 180, Frequency.Biannual, 887_644.5385, 154_175_735.9305)]
    [TestCase(1_358_600, 0.4782, 12, Frequency.Annual, 655_706.8863, 6_509_882.6354)]
    public void CalculateEquatedMonthlyPayment(double principal, double rate, int terms, Frequency paymentFrequency,
        double emi, double totalInterest)
    {
        // Act
        var estimate = AmortizedLoanEstimate.CreateEstimate(principal, rate, terms, paymentFrequency);

        // Assert
        Assert.AreEqual(emi, estimate.EquatedMonthlyInstallment, 4);
        Assert.AreEqual(totalInterest, estimate.TotalInterest, 4);
    }

    [Test]
    public void GetInstallment_ThrowsArgumentException_WhenNumberIsEqualToOrLessThanZero()
    {
        // Assert
        Assert.Throws<ArgumentException>(() => _estimate.GetInstallment(-1));
        Assert.Throws<ArgumentException>(() => _estimate.GetInstallment(0));
    }

    [Test]
    public void GetInstallment_ThrowsArgumentException_WhenInstallmentNumberDoesNotExist()
    {
        // Assert
        Assert.Throws<ArgumentException>(() => _estimate.GetInstallment(7));
    }

    [Test]
    public void GetInstallment_ShouldBeSuccessful_WhenInstallmentNumberDoesExist()
    {
        // Assert
        Assert.DoesNotThrow(() => _estimate.GetInstallment(1));
        Assert.DoesNotThrow(() => _estimate.GetInstallment(2));
        Assert.DoesNotThrow(() => _estimate.GetInstallment(3));
        Assert.DoesNotThrow(() => _estimate.GetInstallment(4));
        Assert.DoesNotThrow(() => _estimate.GetInstallment(5));
        Assert.DoesNotThrow(() => _estimate.GetInstallment(6));
    }

    // [Test]
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
    //     Assert.Throws<ArgumentOutOfRangeException>("paymentFrequency", invalidFrequency);
    // }
}
