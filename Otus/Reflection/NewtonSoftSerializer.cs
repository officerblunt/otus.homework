using System.Diagnostics;
using Newtonsoft.Json;

namespace PlayGround.Otus.Reflection;

public static class NewtonSoftSerializer
{
    public static string Serialize(object serializable, out long timing)
    {
        var sw = new Stopwatch();
        sw.Start();

        var serializedString = string.Empty;

        for (var i = 0; i < 100000; i++)
        {
            serializedString = JsonConvert.SerializeObject(serializable);
        }

        sw.Stop();

        timing = sw.ElapsedMilliseconds;

        return serializedString;
    }

    public static F Deserialize(string json, out long timing)
    {
        var sw = new Stopwatch();
        sw.Start();
        var result = JsonConvert.DeserializeObject<F>(json);
        sw.Stop();
        timing = sw.ElapsedMilliseconds;

        return result!;
    }
}