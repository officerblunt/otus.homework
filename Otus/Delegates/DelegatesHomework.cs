using PlayGround.Otus.Delegates.Util;

namespace PlayGround.Otus.Delegates;

public class DelegatesHomework
{
    public static void Run(string? filePath)
    {
        var root = filePath?.Length > 0 ? filePath : Directory.GetCurrentDirectory();

        Console.WriteLine($"Starting in {root}");
        Console.WriteLine();

        var walker = new FileWalker();

        var foundFiles = new List<FileInfo>();

        walker.FileFound += (sender, e) =>
        {
            Console.WriteLine($"Found: {e.FilePath}");
            foundFiles.Add(new(e.FilePath));

            if (!e.FilePath.EndsWith(".tmp", StringComparison.OrdinalIgnoreCase)) return;

            e.Cancel = true;
        };

        try
        {
            walker.Walk(rootDirectory: root, searchPattern: "*", recursive: true);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while scanning: {ex.Message}");
        }

        Console.WriteLine();
        Console.WriteLine("Result:");

        if (foundFiles.Count == 0)
        {
            Console.WriteLine("There are no files found.");
            return;
        }

        var maxBySize = foundFiles.GetMax(fi => (float)fi.Length);

        Console.WriteLine($"Heaviest file: {maxBySize.FullName}");
        Console.WriteLine($"Size: {maxBySize.Length} bytes");
    }
}