using System.Diagnostics;

namespace PlayGround.Otus.Parallelism;

public static class ParallelismProgram
{
    private const string RESULT_FILE_NAME = "results.txt";

    public static void Start()
    {
        int[] sizes = [100000, 1000000, 10000000];
        var random = new Random();

        foreach (var size in sizes)
        {
            Console.WriteLine($"Array length: {size}");
            File.AppendAllText(RESULT_FILE_NAME, $"Array length: {size}\n");

            var array = GenerateArray(size, random);

            Measure("Synchronously", () => CountSynchronously(array));
            Measure("Thread", () => CountWithThreads(array));
            Measure("PLINQ", () => CountByLinq(array));
        }
    }

    private static int[] GenerateArray(int size, Random random)
    {
        var arr = new int[size];
        for (var i = 0; i < size; i++)
        {
            arr[i] = random.Next(1, 100);
        }

        return arr;
    }

    private static void Measure(string message, Func<int> action)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        action();
        stopwatch.Stop();
        var result = $"({stopwatch.ElapsedMilliseconds} ms)\t [{Environment.CurrentManagedThreadId}] | {message}";
        Console.WriteLine(result);
        File.AppendAllText(RESULT_FILE_NAME, $"{result}\n");
    }

    private static int CountSynchronously(int[] array)
    {
        var result = 0;
        foreach (var t in array)
        {
            result += t;
        }

        return result;
    }

    private static int CountByLinq(int[] array)
    {
        return array.AsParallel().Sum();
    }

    private static int CountWithThreads(int[] array)
    {
        const int numberOfThreads = 4;
        var chunkSize = array.Length / numberOfThreads;

        var partialSums = new int[numberOfThreads];
        var threads = new List<Thread>();

        for (var i = 0; i < numberOfThreads; i++)
        {
            var threadIndex = i;
            threads.Add(new Thread(() =>
            {
                var localSum = 0;
                var start = threadIndex * chunkSize;
                var end = (threadIndex == numberOfThreads - 1) ? array.Length : start + chunkSize;

                for (var j = start; j < end; j++)
                {
                    localSum += array[j];
                }

                partialSums[threadIndex] = localSum;
            }));
        }

        foreach (var t in threads) t.Start();
        foreach (var t in threads) t.Join();

        return partialSums.Sum();
    }
}