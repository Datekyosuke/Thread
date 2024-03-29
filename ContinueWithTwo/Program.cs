internal class Program
{
    private static void Main()
    {
        int a = 3, b = 4;
        Task<int> task = Task.Run<int>(() => Calc(a, b));
        //task.ContinueWith(Continuation);


        task.ContinueWith((t) =>
        {
            Console.WriteLine($"\nПродолжение task Id #{Task.CurrentId}. Thread Id #{Thread.CurrentThread.ManagedThreadId}.");
            Console.WriteLine($"Результат асинхронной операции - {t.Result}");
        });
        Console.ReadKey();
    }
    private static int Calc(int a, int b)
    {
        Console.WriteLine($"Task Id #{Task.CurrentId}. Thread Id #{Thread.CurrentThread.ManagedThreadId}.");
        return a + b;
    }

    private static void Continuation(Task<int> t)
    {
        Console.WriteLine($"\nПродолжение task Id #{Task.CurrentId}. Thread Id #{Thread.CurrentThread.ManagedThreadId}.");
        Console.WriteLine($"Результат асинхронной операции - {t.Result}");
    }
}