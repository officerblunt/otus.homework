using PlayGround.Otus.SOLID.Interfaces.IO;

namespace PlayGround.Otus.SOLID.Implementations.IO;

// Single Responsibility Principle
public class ConsoleIO : IInput, IOutput
{
    public bool TryRead(out int value) => int.TryParse(Console.ReadLine(), out value);

    public void WriteLine(string message) => Console.WriteLine(message);
}