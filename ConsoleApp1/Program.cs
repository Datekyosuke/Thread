internal class Program
{

    private static void Main()
    {
        Console.WriteLine($"Task Id метода Main : {Task.CurrentId ?? -1}");
        Console.WriteLine($"Thread id метода Main : {Thread.CurrentThread.ManagedThreadId}");
        Console.WriteLine(new string('-', 80));

        Task task = new Task(new Action(DoSomething), TaskCreationOptions.PreferFairness | TaskCreationOptions.LongRunning);

        task.Start();
        Thread.Sleep(50);

        for(int i = 0; i < 5; i++)
        {
            Console.WriteLine($"           Метод Main выполняется.");
            Thread.Sleep(100);
        }

        Console.ReadKey();
    }

    private static void DoSomething()
    {
        Console.WriteLine($"Task Id метода DoSomething : {Task.CurrentId}");
        Console.WriteLine($"Thread Id vtnjlf DoSomething : {Thread.CurrentThread.ManagedThreadId}");
        Console.WriteLine(new string('-', 80));

        for (int i = 0; i <5; i++)
        {
            Console.WriteLine($"           Задача выполняется.");
            Thread.Sleep(100);
        }

        Console.WriteLine($"Задача Завершена в потоке : {Thread.CurrentThread.ManagedThreadId}");

    }
}