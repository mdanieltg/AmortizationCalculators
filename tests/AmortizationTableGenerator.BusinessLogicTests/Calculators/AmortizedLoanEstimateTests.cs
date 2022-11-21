using AmortizationTableGenerator.BusinessLogic;
using AmortizationTableGenerator.BusinessLogic.Calculators;

namespace AmortizationTableGenerator.BusinessLogicTests.Calculators;

public class AmortizedLoanEstimateTests
{
    [Fact]
    public void EMI_MonthlyPayment()
    {
        // Prepare
        var principal = 12_000d;
        var rate = 0.025d;
        var rateType = Frequency.Annual;
        var frequency = Frequency.Monthly;
        var terms = 12;

        // Act
        var estimate = AmortizedLoanEstimate.CreateEstimate(principal, rate, rateType, terms, frequency);

        // Assert
        Assert.Equal(1_013.5933, estimate.EquatedMonthlyInstallment, 4);
        Assert.Equal(163.12, estimate.TotalInterest, 4);
    }

    [Fact]
    public void EMI_BimonthlyPayment()
    {
        // Prepare
        var principal = 93_125;
        var rate = 0.35;
        var rateType = Frequency.Annual;
        var frequency = Frequency.Bimonthly;
        var terms = 10;

        // Act
        var estimate = AmortizedLoanEstimate.CreateEstimate(principal, rate, rateType, terms, frequency);

        // Assert
        Assert.Equal(12_552.9842, estimate.EquatedMonthlyInstallment, 4);
        Assert.Equal(32_404.8418, estimate.TotalInterest, 4);
    }

    [Fact]
    public void EMI_QuarterlyPayment()
    {
        // Prepare
        var principal = 6_653;
        var rate = 0.17125;
        var rateType = Frequency.Quarterly;
        var frequency = Frequency.Quarterly;
        var terms = 6;

        // Act
        var estimate = AmortizedLoanEstimate.CreateEstimate(principal, rate, rateType, terms, frequency);

        // Assert
        Assert.Equal(1_859.6659, estimate.EquatedMonthlyInstallment, 4);
        Assert.Equal(4_504.9951, estimate.TotalInterest, 4);
    }

    [Fact]
    public void EMI_QuadrimestralPayment()
    {
        // Prepare
        var principal = 152_056;
        var rate = 0.223;
        var rateType = Frequency.Quarterly;
        var frequency = Frequency.Quadrimestral;
        var terms = 20;

        // Act
        var estimate = AmortizedLoanEstimate.CreateEstimate(principal, rate, rateType, terms, frequency);

        // Assert
        Assert.Equal(45_460.549, estimate.EquatedMonthlyInstallment, 4);
        Assert.Equal(757_154.9790, estimate.TotalInterest, 4);
    }

    [Fact]
    public void EMI_BiannualPayment()
    {
        // Prepare
        var principal = 5_600_281;
        var rate = 0.02641666666667;
        var rateType = Frequency.Monthly;
        var frequency = Frequency.Biannual;
        var terms = 180;

        // Act
        var estimate = AmortizedLoanEstimate.CreateEstimate(principal, rate, rateType, terms, frequency);

        // Assert
        Assert.Equal(887_644.5385, estimate.EquatedMonthlyInstallment, 4);
        Assert.Equal(154_175_735.9305, estimate.TotalInterest, 4);
    }

    [Fact]
    public void EMI_AnnualPayment()
    {
        // Prepare
        var principal = 1_358_600;
        var rate = 0.4782;
        var rateType = Frequency.Annual;
        var frequency = Frequency.Annual;
        var terms = 12;

        // Act
        var estimate = AmortizedLoanEstimate.CreateEstimate(principal, rate, rateType, terms, frequency);

        // Assert
        Assert.Equal(655_706.8863, estimate.EquatedMonthlyInstallment, 4);
        Assert.Equal(6_509_882.6354, estimate.TotalInterest, 4);
    }
}
