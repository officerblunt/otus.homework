namespace PlayGround.Otus.SOLID.Interfaces.Engines;

// Interface Segregation Principle 
public interface IGameEngine
{
    bool TryProcessGuess(int guess, out string message);
}