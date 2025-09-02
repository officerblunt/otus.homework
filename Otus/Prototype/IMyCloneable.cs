namespace PlayGround.Otus.Prototype;

public interface IMyCloneable<out T> where T : class
{
    T Clone();
}