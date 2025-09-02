namespace PlayGround.Otus.AsyncTasks;

public static class TasksProgram
{
    private const string FOLDER_PATH = @"C:\Users\alex\projects\PlayGround\PlayGround\Otus\AsyncTasks";

    public static async Task Start()
    {
        var files = new[]
        {
            Path.Combine(FOLDER_PATH, "test1.txt"),
            Path.Combine(FOLDER_PATH, "test2.txt"),
            Path.Combine(FOLDER_PATH, "test3.txt")
        };

        var tasks = files.Select(CountSpacesInFileAsync).ToArray();

        var results = await Task.WhenAll(tasks);

        for (var i = 0; i < files.Length; i++)
        {
            Console.WriteLine($"{files[i]} contains {results[i]} whitespaces.");
        }

        var folderResults = await CountSpacesInFolderAsync(FOLDER_PATH);

        foreach (var kvp in folderResults)
        {
            Console.WriteLine($"{kvp.Key} contains {kvp.Value} whitespaces.");
        }
    }

    private static async Task<int> CountSpacesInFileAsync(string path)
    {
        if (!File.Exists(path)) throw new FileNotFoundException(path);

        try
        {
            var content = await File.ReadAllTextAsync(path);

            var count = content.Count(c => c == ' ');
            return count;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file {path}: {ex.Message}");
            return 0;
        }
    }

    private static async Task<Dictionary<string, int>> CountSpacesInFolderAsync(string folderPath)
    {
        if (!Directory.Exists(folderPath))
        {
            Console.WriteLine($"Folder {folderPath} not found.");
            return new();
        }

        var files = Directory.GetFiles(folderPath);
        var tasks = files.Select(async file =>
        {
            var count = await CountSpacesInFileAsync(file);
            return (file, count);
        }).ToArray();

        var results = await Task.WhenAll(tasks);
        return results.ToDictionary(r => r.file, r => r.count);
    }
}