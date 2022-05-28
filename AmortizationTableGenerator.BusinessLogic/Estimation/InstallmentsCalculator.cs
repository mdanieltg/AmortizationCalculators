using System.Text;

namespace AmortizationTableGenerator.BusinessLogic.Estimation;

public class InstallmentsCalculator
{
    private static InstallmentsCalculator _instance = new();
    private readonly Dictionary<int, Installment> _installments = new();
    private readonly bool _hasDates;

    private InstallmentsCalculator()
    {
        _installments = new Dictionary<int, Installment>();
        _hasDates = false;
    }

    public InstallmentsCalculator(double rate, double principal, double payment, int terms, double advance,
        Frequency paymentFrequency, DateTime? loanDate = null)
    {
        _hasDates = loanDate is not null;
        var i = 1;

        do
        {
            var date = AddTime(loanDate, i, paymentFrequency);
            var installment = new Installment(i, principal, rate, payment, advance, date);
            Interest += installment.InterestPayment;
            Total += installment.Payment;
            principal = installment.NewPrincipal;

            _installments.Add(i, installment);
            ++i;
        } while (principal > 0 && i <= terms);
    }

    public double Interest { get; }

    public double Total { get; }

    public static InstallmentsCalculator Empty => _instance;

    public Installment? GetInstallment(int number)
    {
        return _installments.ContainsKey(number)
            ? _installments[number]
            : null;
    }

    private static DateTime? AddTime(DateTime? loanDate, int number, Frequency frequency)
    {
        if (loanDate is null) return null;

        var date = loanDate.Value;
        return frequency switch
        {
            Frequency.Weekly => date.AddDays(7 * number),
            Frequency.Biweekly => date.AddDays(15 * number),
            Frequency.Monthly => date.AddMonths(1 * number),
            Frequency.Bimonthly => date.AddMonths(2 * number),
            Frequency.Quarterly => date.AddMonths(3 * number),
            Frequency.Quadrimestral => date.AddMonths(4 * number),
            Frequency.Biannual => date.AddMonths(6 * number),
            Frequency.Annual => date.AddYears(1 * number),
            _ => throw new ArgumentOutOfRangeException(nameof(frequency), frequency, null)
        };
    }

    public string GetTable()
    {
        var sb = new StringBuilder();

        if (!_hasDates)
        {
            sb.AppendLine(
                $" {"#",-3} | {"Principal",-12} | {"Payment",-12} | {"To Principal",-12} | {"To Interest",-12} | {"New Principal",-13}");
            sb.AppendLine(" --- | ------------ | ------------ | ------------ | ------------ | ------------- ");
        }
        else
        {
            sb.AppendLine(
                $@" {"#",-3} | {"Date",-12} | {"Principal",-12} | {"Payment",-12} | {"To Principal",-12} | {"To Interest",-12} | {"New Principal",-13}");
            sb.AppendLine(
                " --- | ------------ | ------------ | ------------ | ------------ | ------------ | ------------- ");
        }

        foreach (var installment in _installments.Values)
        {
            sb.AppendLine(installment.GetLine());
        }

        return sb.ToString();
    }

    public void PrintTable(TextWriter writer)
    {
        writer.Write(GetTable());
    }
}
