using System.Diagnostics;

namespace PlayGround.Otus.Reflection;

public static class CustomSerializer
{
    public static string Serialize(object serializable, out long timing)
    {
        var sw = new Stopwatch();
        sw.Start();
        var type = serializable.GetType();
        var serializableFields = type.GetFields();

        var serializedString = string.Empty;

        for (var i = 0; i < 100000; i++)
        {
            serializedString = serializableFields.Aggregate(string.Empty,
                (current, field) => current + field.GetValue(serializable));
        }

        sw.Stop();
        timing = sw.ElapsedMilliseconds;

        return serializedString;
    }

    public static F Deserialize(string csv, out long timing)
    {
        var sw = new Stopwatch();
        sw.Start();
        var s = csv.AsSpan();
        var f = new F();
        f.I1 = ReadNextInt(ref s);
        f.I2 = ReadNextInt(ref s);
        f.I3 = ReadNextInt(ref s);
        f.I4 = ReadNextInt(ref s);
        f.I5 = ReadLastInt(s);
        sw.Stop();

        timing = sw.ElapsedMilliseconds;

        return f;
    }

    private static int ReadNextInt(ref ReadOnlySpan<char> s)
    {
        var comma = s.IndexOf(',');
        var token = s[..comma];
        s = s[(comma + 1)..];
        return int.Parse(token);
    }

    private static int ReadLastInt(ReadOnlySpan<char> s) => int.Parse(s);
}