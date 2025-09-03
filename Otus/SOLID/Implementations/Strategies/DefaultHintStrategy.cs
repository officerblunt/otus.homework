using PlayGround.Otus.SOLID.Common;
using PlayGround.Otus.SOLID.Interfaces.Strategies;

namespace PlayGround.Otus.SOLID.Implementations.Strategies;

// Single Responsibility Principle
// Open-Closed Principle
// Liskov Substitution Principle
public class DefaultHintStrategy : IHintStrategy
{
    public string BuildHint(ComparisonResult comparison, int attemptsLeft) => comparison switch
    {
        ComparisonResult.Greater => $"The secret number is greater. Attempts left: {attemptsLeft}.",
        ComparisonResult.Less => $"The secret number is less. Attempts left: {attemptsLeft}.",
        _ => string.Empty
    };
}