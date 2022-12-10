using AmortizationCalculators.BusinessLogic;

namespace AmortizationCalculators.ConsoleApp.Util;

public class InputModule
{
    public static double ReadPrincipal()
    {
        while (true)
        {
            Console.Write("Principal: $");
            var tryParse = double.TryParse(Console.ReadLine(), out var principal);
            if (!tryParse || principal <= 0)
            {
                Console.WriteLine("Invalid value, please try again.");
                continue;
            }

            return principal;
        }
    }

    public static double ReadRate()
    {
        while (true)
        {
            Console.Write("Annual interest rate (%): ");
            var tryParse = double.TryParse(Console.ReadLine(), out var rate);
            if (!tryParse || rate <= 0)
            {
                Console.WriteLine("Invalid value, please try again.");
                continue;
            }

            return rate / 100d;
        }
    }

    public static Frequency ReadFrequency()
    {
        while (true)
        {
            Console.Write("Payment frequency: ");
            var frequency = Console.ReadLine()?.Trim().ToLowerInvariant();

            try
            {
                return frequency switch
                {
                    "monthly" => Frequency.Monthly,
                    "bimonthly" => Frequency.Bimonthly,
                    "quarterly" => Frequency.Quarterly,
                    "quadrimestral" => Frequency.Quadrimestral,
                    "biannual" => Frequency.Biannual,
                    "annual" => Frequency.Annual,
                    _ => throw new ArgumentOutOfRangeException()
                };
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid value, please try again.");
            }
        }
    }

    public static int ReadTerms()
    {
        while (true)
        {
            Console.Write("Amount of payments: ");
            var tryParse = int.TryParse(Console.ReadLine(), out var numberOfPayments);
            if (!tryParse || numberOfPayments < 1)
            {
                Console.WriteLine("Invalid value, please try again.");
                continue;
            }

            return numberOfPayments;
        }
    }
}
