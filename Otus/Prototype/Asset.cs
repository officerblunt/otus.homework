namespace PlayGround.Otus.Prototype;

/// <summary>
/// Базовый ресурс: имеет Id, Name и Tags.
/// </summary>
public class Asset : IMyCloneable<Asset>, ICloneable
{
    public Guid Id { get; init; }
    public string Name { get; set; }
    public List<string> Tags { get; } = [];

    public Asset(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    protected Asset(Asset other)
    {
        Id = other.Id;
        Name = other.Name;
        Tags = new List<string>(other.Tags);
    }

    public virtual Asset Clone() => new(this);

    object ICloneable.Clone() => Clone();
}