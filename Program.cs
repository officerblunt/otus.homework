using PlayGround.Otus.AsyncTasks;
using PlayGround.Otus.Parallelism;
using PlayGround.Otus.Prototype;
using PlayGround.Otus.SOLID.Implementations;
using PlayGround.Otus.SOLID.Implementations.GameSettings;

public static class Program
{
    public static void Main()
    {
        // ДЗ по теме "Внутрипроцессное взаимодействие"
        ParallelismProgram.Start();

        // ДЗ по теме "Порождающие шаблоны проектирования"
        PrototypeProgram.Start();

        // ДЗ по теме "Введение в параллелизм в .NET. Отличия процесса, потока, домена и таска"
        _ = TasksProgram.Start();

        // ДЗ по теме "Принципы SOLID"
        Game.Run(new CustomMode(1, 10, 100));
    }
}