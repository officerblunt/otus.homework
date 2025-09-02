using PlayGround.Otus.AsyncTasks;
using PlayGround.Otus.Parallelism;
using PlayGround.Otus.Prototype;

public static class Program
{
    public static void Main(string[] args)
    {
        // ДЗ по теме "Внутрипроцессное взаимодействие"
        ParallelismProgram.Start();
        
        // ДЗ по теме "Порождающие шаблоны проектирования"
        PrototypeProgram.Start();
        
        // ДЗ по теме "Введение в параллелизм в .NET. Отличия процесса, потока, домена и таска"
        _ = TasksProgram.Start();
    }
}