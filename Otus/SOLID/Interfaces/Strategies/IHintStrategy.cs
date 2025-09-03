using PlayGround.Otus.SOLID.Common;

namespace PlayGround.Otus.SOLID.Interfaces.Strategies;

// Open-Closed Principle
public interface IHintStrategy
{
    string BuildHint(ComparisonResult comparison, int attemptsLeft);
}