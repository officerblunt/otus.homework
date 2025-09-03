using PlayGround.Otus.SOLID.Interfaces.Settings;

namespace PlayGround.Otus.SOLID.Util;

// Single Responsibility Principle

public static class Guard
{
    public static IGameSettings Validate(IGameSettings s)
    {
        ArgumentNullException.ThrowIfNull(s);
        if (s.MaxRetryAttempts <= 0) throw new ArgumentOutOfRangeException(nameof(s.MaxRetryAttempts));
        if (s.MinNumber >= s.MaxNumber) throw new ArgumentOutOfRangeException(nameof(s), "MinNumber must be less than MaxNumber.");
        return s;
    }
}