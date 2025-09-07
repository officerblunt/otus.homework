namespace PlayGround.Otus.Delegates.EventArgs;

public class FileFoundEventArgs(string filePath) : System.EventArgs
{
    /// <summary>Полный путь к файлу.</summary>
    public string FilePath { get; } = filePath ?? throw new ArgumentNullException(nameof(filePath));

    /// <summary>Установите true в обработчике для отмены дальнейшего поиска.</summary>
    public bool Cancel { get; set; }
}