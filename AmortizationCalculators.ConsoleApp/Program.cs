using AmortizationCalculators.ConsoleApp.Estimations;

Console.WriteLine("Amortization Calculator");

// Menu
while (true)
{
    Console.WriteLine("Select an option:");
    Console.WriteLine("1. Quick estimation");
    Console.WriteLine("2. New estimation");
    Console.WriteLine("3. Open estimation");
    Console.WriteLine("0. Exit");
    Console.WriteLine();
    Console.Write("Selection: ");

    var selection = Console.ReadKey();

    if (selection.KeyChar == '0')
    {
        // Exit
        break;
    }
    else if (selection.KeyChar == '1')
    {
        // Quick estimation
        Console.Clear();
        await QuickEstimation.Calculate();
    }
    else if (selection.KeyChar == '2')
    {
        // New estimation
        Console.Clear();
    }
    else
    {
        // Invalid option
        Console.WriteLine("No option or valid option was selected.");
        Console.WriteLine();
    }

    Console.Clear();
}
