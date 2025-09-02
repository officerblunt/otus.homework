namespace PlayGround.Otus.Prototype;

/// <summary>
/// Документ, имеет содержание и дату создания.
/// </summary>
public class Document : Asset, IMyCloneable<Document>, ICloneable
{
    public string Content { get; set; }
    public DateTime CreatedAt { get; init; }

    public Document(Guid id, string name, string content, DateTime createdAt) : base(id, name)
    {
        Content = content;
        CreatedAt = createdAt;
    }

    protected Document(Document other) : base(other)
    {
        Content = other.Content;
        CreatedAt = other.CreatedAt;
    }

    public override Document Clone() => new(this);

    object ICloneable.Clone() =>  Clone();
}