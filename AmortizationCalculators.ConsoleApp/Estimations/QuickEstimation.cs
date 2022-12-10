using System.Transactions;
using AmortizationCalculators.BusinessLogic;
using AmortizationCalculators.BusinessLogic.Estimations.Simple;
using AmortizationCalculators.ConsoleApp.Util;

namespace AmortizationCalculators.ConsoleApp.Estimations;

public class QuickEstimation
{
    public static async Task Calculate()
    {
        double principal, interestRate;
        int numberOfPayments;
        Frequency paymentFrequency;

        Console.Write("Principal: $");
        double.TryParse(Console.ReadLine(), out principal);

        Console.Write("Annual interest rate (%): ");
        double.TryParse(Console.ReadLine(), out var rate);
        interestRate = rate / 100d;

        Console.Write("Payment frequency: ");
        var freq = Console.ReadLine()?.Trim().ToLowerInvariant();
        paymentFrequency = freq switch
        {
            "monthly" => Frequency.Monthly,
            "bimonthly" => Frequency.Bimonthly,
            "quarterly" => Frequency.Quarterly,
            "quadrimestral" => Frequency.Quadrimestral,
            "biannual" => Frequency.Biannual,
            "annual" => Frequency.Annual,
            _ => throw new ArgumentOutOfRangeException()
        };

        Console.Write("Amount of payments: ");
        int.TryParse(Console.ReadLine(), out numberOfPayments);

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
