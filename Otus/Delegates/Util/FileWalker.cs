using PlayGround.Otus.Delegates.EventArgs;

namespace PlayGround.Otus.Delegates.Util;

public class FileWalker
{
    public event EventHandler<FileFoundEventArgs>? FileFound;

    public void Walk(string rootDirectory, string searchPattern = "*", bool recursive = true)
    {
        if (string.IsNullOrWhiteSpace(rootDirectory))
            throw new ArgumentException("Failed to initialize specified catalogue.", nameof(rootDirectory));
        if (!Directory.Exists(rootDirectory))
            throw new DirectoryNotFoundException($"Catalogue not found: {rootDirectory}");

        var option = recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;

        foreach (var file in Directory.EnumerateFiles(rootDirectory, searchPattern, option))
        {
            var args = new FileFoundEventArgs(file);
            OnFileFound(args);
            if (args.Cancel)
                break;
        }
    }

    private void OnFileFound(FileFoundEventArgs e)
    {
        FileFound?.Invoke(this, e);
    }
}