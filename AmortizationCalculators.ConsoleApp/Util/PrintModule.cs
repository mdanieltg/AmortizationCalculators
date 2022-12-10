using AmortizationCalculators.BusinessLogic.Estimations;

namespace AmortizationCalculators.ConsoleApp.Util;

public class PrintModule
{
    public static async Task Print(IPrintableEstimate estimate)
    {
        while (true)
        {
            Console.Write("Press P to print to file or any other key to go back to the main menu: ");
            var selection = Console.ReadKey();
            Console.WriteLine();

            if (selection.Key == ConsoleKey.P)
            {
                // Print to file
                Console.Write("Enter the file name (full path preferred): ");
                var filename = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(filename))
                {
                    Console.WriteLine("Invalid file name, please try again.");
                    continue;
                }

                try
                {
                    IPrinter filePrinter = new FilePrinter();
                    await filePrinter.PrintAsync(filename, estimate);
                    Console.WriteLine($"Successfully printed to {filename}");
                }
                catch (Exception e)
                {
                    Console.WriteLine("There was an error printing the estimate.");
                    Console.Error.WriteLine(e.Message);
                }
            }
            else
            {
                break;
            }
        }
    }
}
