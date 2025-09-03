using PlayGround.Otus.SOLID.Implementations.Engines;
using PlayGround.Otus.SOLID.Implementations.Randomization;
using PlayGround.Otus.SOLID.Implementations.Strategies;
using PlayGround.Otus.SOLID.Interfaces.Generators;
using PlayGround.Otus.SOLID.Interfaces.IO;
using PlayGround.Otus.SOLID.Interfaces.Settings;
using PlayGround.Otus.SOLID.Interfaces.Strategies;

namespace PlayGround.Otus.SOLID.Implementations;

// Single Responsibility Principle
// Dependency Inversion Principle
public class Game
{
    public static void Run(IGameSettings settings, bool useHotColdHints = false)
    {
        IInput input = new IO.ConsoleIO();
        IOutput output = (IO.ConsoleIO)input;

        var generator = new RandomNumberGenerator();
        var hints = new DefaultHintStrategy();
        
        Run(settings, input, output, generator, hints);
    }

    private static void Run(IGameSettings settings, IInput input, IOutput output,
        INumberGenerator generator, IHintStrategy hints)
    {
        var engine = new GameEngine(settings, generator, hints);

        output.WriteLine($"Starting game. Range: {settings.MinNumber}..{settings.MaxNumber}. " +
                         $"Attempts: {settings.MaxRetryAttempts}. Enter a number:");

        while (true)
        {
            if (!input.TryRead(out var guess))
            {
                output.WriteLine("This is not a valid integer. Try again:");
                continue;
            }

            var finished = engine.TryProcessGuess(guess, out var msg);
            output.WriteLine(msg);
            if (finished) break;
        }
    }
}