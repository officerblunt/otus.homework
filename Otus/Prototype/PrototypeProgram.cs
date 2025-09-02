namespace PlayGround.Otus.Prototype;

public static class PrototypeProgram
{
    public static void Start()
    {
        var original = new FinancialReport(
            id: Guid.NewGuid(),
            name: "test report 1",
            content: "test report 1 content",
            createdAt: DateTime.UtcNow,
            author: "me"
        );

        original.Tags.AddRange(["test", "1", "2"]);
        original.Sections.AddRange(["test1", "test2", "test3"]);
        original.Metrics["a"] = 123;
        original.Metrics["b"] = 456;

        var clone = original.Clone();

        clone.Name = "test report 2";
        clone.Tags.Add("copy");
        clone.Sections.Add("test2");
        clone.Metrics["test2"] = 789;
    }
}