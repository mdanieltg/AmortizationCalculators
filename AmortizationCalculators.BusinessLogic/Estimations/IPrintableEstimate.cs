using System.Diagnostics;

namespace AmortizationCalculators.BusinessLogic.Estimations;

public interface IPrintableEstimate
{
    // string GetInformation();
    // string GetTable();
    void PrintEstimate(TextWriter output);
    Task PrintEstimateAsync(TextWriter output);
}
