using PlayGround.Otus.AsyncTasks;
using PlayGround.Otus.Delegates;
using PlayGround.Otus.Parallelism;
using PlayGround.Otus.Prototype;
using PlayGround.Otus.Reflection;
using PlayGround.Otus.SOLID.Implementations;
using PlayGround.Otus.SOLID.Implementations.GameSettings;

namespace PlayGround;

public static class Program
{
    public static async Task Main()
    {
        // ДЗ по теме "Внутрипроцессное взаимодействие"
        ParallelismProgram.Start();

        // ДЗ по теме "Порождающие шаблоны проектирования"
        PrototypeProgram.Start();

        // ДЗ по теме "Введение в параллелизм в .NET. Отличия процесса, потока, домена и таска"
        await TasksProgram.StartAsync();

        // ДЗ по теме "Принципы SOLID"
        Game.Run(new CustomMode(1, 10, 100));

        // ДЗ по теме "Отражение (Reflection)"
        var operableObject = new F();
        var customSerializedString = CustomSerializer.Serialize(operableObject, out var cst);
        var newtonsoftDeserializedString = NewtonSoftSerializer.Serialize(operableObject, out var nst);

        Console.WriteLine(
            $"---- Custom serialization ----\nResult: {customSerializedString}\nIDE: JetBrains Rider Windows\nTime elapsed: {cst} ms");
        Console.WriteLine(
            $"---- NewtonSoft serialization ----\nResult: {newtonsoftDeserializedString}\nIDE: JetBrains Rider Windows\nTime elapsed: {nst} ms");

        // ДЗ по теме "Работа с методами как с переменными (delegates, events)"
        DelegatesHomework.Run(null);
    }
}