using PlayGround.Otus.SOLID.Interfaces;
using PlayGround.Otus.SOLID.Interfaces.Generators;

namespace PlayGround.Otus.SOLID.Implementations.Randomization;

// Single Responsibility Principle
// Dependency Inversion Principle
public sealed class RandomNumberGenerator : INumberGenerator
{
    private readonly Random _rng = new();

    public int Generate(int min, int max)
    {
        ArgumentOutOfRangeException.ThrowIfEqual(max, int.MinValue);

        return _rng.Next(min, max + 1);
    }
}