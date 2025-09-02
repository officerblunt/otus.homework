namespace PlayGround.Otus.Prototype;

/// <summary>
/// Отчёт, имеет автора и список разделов.
/// </summary>
public class Report : Document, IMyCloneable<Report>, ICloneable
{
    public string Author { get; set; }
    public List<string> Sections { get; } = [];

    public Report(Guid id, string name, string content, DateTime createdAt, string author) : base(id, name, content,
        createdAt)
    {
        Author = author;
    }

    protected Report(Report other) : base(other)
    {
        Author = other.Author;
        Sections = new(other.Sections);
    }

    public override Report Clone() => new(this);
    
    object ICloneable.Clone() => Clone();
}