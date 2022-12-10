using AmortizationCalculators.BusinessLogic.Estimations.Simple;
using AmortizationCalculators.ConsoleApp.Util;

namespace AmortizationCalculators.ConsoleApp.Estimations;

public class QuickEstimation
{
    public static async Task Calculate()
    {
        var principal = InputModule.ReadPrincipal();
        var interestRate = InputModule.ReadRate();
        var paymentFrequency = InputModule.ReadFrequency();
        var numberOfPayments = InputModule.ReadTerms();

        var estimate = AmortizedLoanEstimate.CreateEstimate(
            principal: principal,
            interestRate: interestRate,
            terms: numberOfPayments,
            paymentFrequency: paymentFrequency);

        Console.WriteLine();
        estimate.PrintEstimate(Console.Out);
        Console.WriteLine();

        await PrintModule.Print(estimate);
    }
}
