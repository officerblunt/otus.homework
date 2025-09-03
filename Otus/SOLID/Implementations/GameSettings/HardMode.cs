using PlayGround.Otus.SOLID.Interfaces;
using PlayGround.Otus.SOLID.Interfaces.Settings;

namespace PlayGround.Otus.SOLID.Implementations.GameSettings;

public class HardMode : IGameSettings
{
    public int MinNumber { get; init; } = 1;
    public int MaxNumber { get; init; } = 100;
    public int MaxRetryAttempts { get; init; } = 8;
}