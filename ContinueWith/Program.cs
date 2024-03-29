internal class Program
{
    private static void Main()
    {
        Task task = new Task(new Action<object>(OperationAsync), "Hello world");

        Task continuation = task.ContinueWith(Continuation);

        Console.WriteLine($"Ставтус продолжения - {continuation.Status}");

        task.Start();
        Console.ReadKey();
    }
        private static void OperationAsync(object arg)
    {
        Console.WriteLine($"Задача #{Task.CurrentId} началась в потоке {Thread.CurrentThread.ManagedThreadId}.");
        Console.WriteLine($"Argument value - {arg.ToString()}");
        Console.WriteLine($"Задача #{Task.CurrentId} завершилась в потоке {Thread.CurrentThread.ManagedThreadId}.");
    }

    private static void Continuation(Task task)
    {
        Console.Write($"\nПродолжение #{Task.CurrentId} сработало в потоке {Thread.CurrentThread.ManagedThreadId}. ");
        Console.WriteLine($"Параметр задачи - {task.AsyncState}");
        Console.WriteLine($"Сразу после выполнения задачи.");
    }
}