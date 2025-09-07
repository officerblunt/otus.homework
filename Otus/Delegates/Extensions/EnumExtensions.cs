namespace PlayGround.Otus.Delegates;

public static class EnumExtensions
{
    public static T GetMax<T>(this IEnumerable<T> source, Func<T, float> convertToNumber) where T : class
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(convertToNumber);

        using var e = source.GetEnumerator();
        if (!e.MoveNext())
            throw new InvalidOperationException("Невозможно определить максимум для пустой последовательности.");

        var bestItem = e.Current!;
        var bestValue = convertToNumber(bestItem);

        while (e.MoveNext())
        {
            var curr = e.Current!;
            var value = convertToNumber(curr);
            if (!(value > bestValue) && !float.IsNaN(bestValue)) continue;
            bestItem = curr;
            bestValue = value;
        }

        return bestItem;
    }
}