using System.Text;

namespace AmortizationTableGenerator.BusinessLogic.Estimation;

public class AmortizedLoanEstimate
{
    private double _advance;

    // private InstallmentsCalculator? _installments;
    private double _interestRate;
    private DateTime? _loanDate;
    private Frequency _paymentFrequency;
    private double _principal;
    private Frequency _rateType;
    private int _terms;

    public AmortizedLoanEstimate()
    {
        ParameterChangedEvent += ParameterChangedEventHandler;
    }

    public AmortizedLoanEstimate(double principal, double interestRate, int terms, double advance = 0,
        DateTime? loanDate = null, Frequency rateType = Frequency.Annual,
        Frequency paymentFrequency = Frequency.Monthly)
    {
        Principal = principal;
        InterestRate = interestRate;
        Terms = terms;
        RateType = rateType;
        PaymentFrequency = paymentFrequency;
        LoanDate = loanDate;
        Advance = advance;

        ParameterChangedEvent += ParameterChangedEventHandler;
        // ParameterChangedEvent.Invoke(this, null);
        ParameterChangedEventHandler(this, null);
    }

    public double Principal
    {
        get => _principal;
        set
        {
            if (value <= 0) throw new ArgumentException();
            _principal = value;
            ParameterChangedEvent?.Invoke(this, null);
        }
    }

    public double InterestRate
    {
        get => _interestRate;
        set
        {
            if (value < 0) throw new ArgumentException();
            _interestRate = value;
            ParameterChangedEvent?.Invoke(this, null);
        }
    }

    public Frequency RateType
    {
        get => _rateType;
        set
        {
            if (!Enum.IsDefined(typeof(Frequency), value)) throw new ArgumentException();
            _rateType = value;
            ParameterChangedEvent?.Invoke(this, null);
        }
    }

    public double AnnualInterestRate => InterestRate * AmortizationCalculator.GetValue(RateType);

    public int Terms
    {
        get => _terms;
        set
        {
            if (value <= 0) throw new ArgumentException();
            _terms = value;
            ParameterChangedEvent?.Invoke(this, null);
        }
    }

    public Frequency PaymentFrequency
    {
        get => _paymentFrequency;
        set
        {
            if (!Enum.IsDefined(typeof(Frequency), value)) throw new ArgumentException();
            _paymentFrequency = value;
            ParameterChangedEvent?.Invoke(this, null);
        }
    }

    public double Advance
    {
        get => _advance;
        set
        {
            if (value < 0) throw new ArgumentException();
            _advance = value;
            ParameterChangedEvent?.Invoke(this, null);
        }
    }

    public double EquatedMonthlyInstallment { get; private set; }

    public DateTime? LoanDate
    {
        get => _loanDate;
        set
        {
            _loanDate = value;
            ParameterChangedEvent?.Invoke(this, null);
        }
    }

    public DateTime EstimationDate { get; private set; }

    public InstallmentsCalculator Installments { get; private set; } = InstallmentsCalculator.Empty;

    private event ChangedParameterHandler? ParameterChangedEvent;

    private void ParameterChangedEventHandler(object sender, EventArgs? args)
    {
        // Set estimation date
        EstimationDate = DateTime.Now;

        // Recalculate EMI
        EquatedMonthlyInstallment = AmortizationCalculator.GetEquatedMonthlyInstallment(
            Principal,
            AnnualInterestRate,
            Terms,
            PaymentFrequency);

        // Recreate installments
        Installments = new InstallmentsCalculator(
            AnnualInterestRate / AmortizationCalculator.GetValue(PaymentFrequency),
            Principal,
            EquatedMonthlyInstallment,
            Terms,
            Advance,
            PaymentFrequency,
            LoanDate);
    }

    public string GetInformation()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"Estimation date: {EstimationDate:D}");
        sb.AppendLine($"Loan date: {LoanDate:D}");
        sb.AppendLine();

        sb.Append($"Principal: {Principal,12:C}");
        sb.Append($"  Installment: {EquatedMonthlyInstallment,12:C}");
        sb.AppendLine($"     Rate: {InterestRate,8:P} {RateType.ToString().ToLowerInvariant()}");
        sb.Append($" Interest: {Installments.Interest,12:C}");
        sb.Append($"      Advance: {Advance,12:C}");
        sb.AppendLine($"    Terms: {Terms,6:N0}");
        sb.Append($"    Total: {Installments.Total,12:C}");
        sb.AppendLine($"      Payment: {EquatedMonthlyInstallment + Advance,12:C}");

        return sb.ToString();
    }

    public string GetReport()
    {
        return $"{GetInformation()}{Environment.NewLine}{Installments.GetTable()}{Environment.NewLine}";
    }

    public void PrintInformation(TextWriter writer)
    {
        writer.Write(GetInformation());
    }

    public void PrintReport(TextWriter writer)
    {
        writer.Write(GetReport());
    }

    private delegate void ChangedParameterHandler(object sender, EventArgs? args);
}
