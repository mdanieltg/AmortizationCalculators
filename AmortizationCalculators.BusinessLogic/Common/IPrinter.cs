namespace AmortizationCalculators.BusinessLogic.Common;

public interface IPrinter
{
    string GetInformation();
    string GetTable();
    void PrintEstimate(TextWriter output);
}
