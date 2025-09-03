using PlayGround.Otus.SOLID.Interfaces;
using PlayGround.Otus.SOLID.Interfaces.Settings;

namespace PlayGround.Otus.SOLID.Implementations.GameSettings;

public class CustomMode(int minNumber, int maxNumber, int maxRetryAttempts) : IGameSettings
{
    public int MinNumber { get; init; } = minNumber;
    public int MaxNumber { get; init; } = maxNumber;
    public int MaxRetryAttempts { get; init; } = maxRetryAttempts;
}