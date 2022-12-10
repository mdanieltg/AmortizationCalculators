using AmortizationCalculators.BusinessLogic.Estimations;

namespace AmortizationCalculators.ConsoleApp.Util;

public class FilePrinter : IPrinter
{
    public async Task PrintAsync(string filename, IPrintableEstimate estimate)
    {
        if (string.IsNullOrEmpty(filename)) throw new ArgumentNullException(nameof(filename));

        using var fileHandle = File.Open(filename, FileMode.Truncate, FileAccess.Write);
        var writer = new StreamWriter(fileHandle);
        await estimate.PrintEstimateAsync(writer);
        await writer.FlushAsync();
    }
}
