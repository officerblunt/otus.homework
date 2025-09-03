namespace PlayGround.Otus.SOLID.Interfaces.Generators;

// Interface Segregation Principle 
// Dependency Inversion Principle
public interface INumberGenerator
{
    int Generate(int min, int max);
}