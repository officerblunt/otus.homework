using PlayGround.Otus.SOLID.Common;
using PlayGround.Otus.SOLID.Interfaces.Engines;
using PlayGround.Otus.SOLID.Interfaces.Generators;
using PlayGround.Otus.SOLID.Interfaces.Settings;
using PlayGround.Otus.SOLID.Interfaces.Strategies;
using PlayGround.Otus.SOLID.Util;

namespace PlayGround.Otus.SOLID.Implementations.Engines;

// Dependency Inversion Principle
// Liskov Substitution Principle
// Open-Closed Principle
// Single Responsibility Principle
public class GameEngine : IGameEngine
{
    private readonly IGameSettings _settings;
    private readonly IHintStrategy _hints;
    private readonly int _target;
    private int _attemptsLeft;

    public GameEngine(IGameSettings settings, INumberGenerator generator, IHintStrategy hints)
    {
        _settings = Guard.Validate(settings);
        _hints = hints ?? throw new ArgumentNullException(nameof(hints));

        _target = generator.Generate(_settings.MinNumber, _settings.MaxNumber);
        _attemptsLeft = _settings.MaxRetryAttempts;
    }

    public bool TryProcessGuess(int guess, out string message)
    {
        if (_attemptsLeft <= 0)
        {
            message = $"Attempts are over. The secret number was {_target}.";
            return true;
        }

        _attemptsLeft--;

        var cmp = Compare(guess, _target);
        if (cmp == ComparisonResult.Equal)
        {
            message = "You guessed it!";
            return true;
        }

        message = _hints.BuildHint(cmp, _attemptsLeft);

        if (_attemptsLeft == 0)
        {
            message += Environment.NewLine + $"Attempts are over. The secret number was {_target}.";
            return true;
        }

        return false;
    }

    private static ComparisonResult Compare(int guess, int target)
        => guess == target ? ComparisonResult.Equal
            : guess < target ? ComparisonResult.Greater
            : ComparisonResult.Less;
}