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
        Assert.That(estimate.EquatedMonthlyInstallment, Is.EqualTo(emi).Within(0.00009));
        Assert.That(estimate.TotalInterest, Is.EqualTo(totalInterest).Within(0.00009));
    }

    [Test]
    public void GetInstallment_ThrowsArgumentException_WhenNumberIsEqualToOrLessThanZero()
    {
        // Assert
        Assert.That(() => _estimate.GetInstallment(-1), Throws.ArgumentException);
        Assert.That(() => _estimate.GetInstallment(0), Throws.ArgumentException);
    }

    [Test]
    public void GetInstallment_ThrowsArgumentException_WhenInstallmentNumberDoesNotExist()
    {
        // Assert
        Assert.That(() => _estimate.GetInstallment(7), Throws.ArgumentException);
    }

    [TestCase(1, 699, 121.65, 112.91, 8.74, 586.09)]
    [TestCase(2, 586.09, 121.65, 114.32, 7.33, 471.76)]
    [TestCase(3, 471.76, 121.65, 115.75, 5.9, 356.01)]
    [TestCase(4, 356.01, 121.65, 117.2, 4.45, 238.81)]
    [TestCase(5, 238.81, 121.65, 118.66, 2.99, 120.15)]
    [TestCase(6, 120.15, 121.65, 120.15, 1.5, 0d)]
    public void GetInstallment_ShouldReturnTheCorrectInformation(int installmentNumber, double principal, double emi,
        double toPrincipal, double toInterest, double newPrincipal)
    {
        var installment = _estimate.GetInstallment(installmentNumber);
        Assert.That(installment.InstallmentNumber, Is.EqualTo(installmentNumber));
        Assert.That(installment.Principal, Is.EqualTo(principal).Within(0.009));
        Assert.That(installment.Payment, Is.EqualTo(emi).Within(0.009));
        Assert.That(installment.PrincipalPayment, Is.EqualTo(toPrincipal).Within(0.009));
        Assert.That(installment.InterestPayment, Is.EqualTo(toInterest).Within(0.009));
        Assert.That(installment.NewPrincipal, Is.EqualTo(newPrincipal).Within(0.009));
    }
}
