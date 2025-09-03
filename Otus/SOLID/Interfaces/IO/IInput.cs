namespace PlayGround.Otus.SOLID.Interfaces.IO;

// Interface Segregation Principle 
// Dependency Inversion Principle
public interface IInput
{
    bool TryRead(out int value);
}