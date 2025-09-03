namespace PlayGround.Otus.SOLID.Interfaces.Settings;

public interface IGameSettings
{
    int MinNumber { get; init; }
    int MaxNumber { get; init; }
    int MaxRetryAttempts { get; init; }
}