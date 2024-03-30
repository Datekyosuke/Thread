internal class Program
{
    private static void Main()
    {
        Task<int> task = Task.Run<int>(new Func<int>(GetValue));
        task.ContinueWith(Increment)
        .ContinueWith(Increment)
        .ContinueWith(Increment)
        .ContinueWith(Increment)
        .ContinueWith(Increment)
        .ContinueWith(ShowRes);
        Console.WriteLine("Main завершил свою работу");
        Console.ReadKey();
    }
    private static int GetValue()
    {
        return 10;
    }

    private static int Increment(Task<int> t)
    {
        Console.WriteLine($"Продолжение task ID #{Task.CurrentId}, Thread Id {Thread.CurrentThread.ManagedThreadId}");
        return t.Result + 1;
    }

    private static void ShowRes(Task<int> t)
    {
        Console.WriteLine($"Продолжение task Id #{Task.CurrentId}. Thread Id #{Thread.CurrentThread.ManagedThreadId}.");
        Console.WriteLine($"Результат - {t.Result}");
    }
}