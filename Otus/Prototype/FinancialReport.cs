namespace PlayGround.Otus.Prototype;

/// <summary>
/// Финансовый отчёт, содержит словарь метрик.
/// </summary>
public class FinancialReport : Report, IMyCloneable<FinancialReport>, ICloneable
{
    public Dictionary<string, decimal> Metrics { get; } = new();

    public FinancialReport(Guid id, string name, string content, DateTime createdAt, string author) : base(id, name,
        content, createdAt, author)
    {
    }

    protected FinancialReport(FinancialReport other) : base(other)
    {
        Metrics = new(other.Metrics);
    }

    public override FinancialReport Clone() => new FinancialReport(this);
    object ICloneable.Clone() => Clone();
}