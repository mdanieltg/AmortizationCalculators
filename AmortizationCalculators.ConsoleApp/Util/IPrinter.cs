using AmortizationCalculators.BusinessLogic.Estimations;

namespace AmortizationCalculators.ConsoleApp.Util;

public interface IPrinter
{
    Task PrintAsync(string filename, IPrintableEstimate estimate);
}
