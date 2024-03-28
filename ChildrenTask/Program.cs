internal class Program
{

    private static void Main()
    {
        Task[] task = new Task[] { 
            new Task(DoSomethings,1000),
            new Task(DoSomethings,800),
            new Task(DoSomethings,2000),
            new Task(DoSomethings,1000),
            new Task(DoSomethings,3500),
        };

        Console.WriteLine($"Метод Main выполдняется...");
        foreach(Task t in task) t.Start();

        Console.WriteLine($"Метод Main ожидает...");
        foreach (Task t in task) t.Wait();

        Console.WriteLine($"Метод Main продолжает свою работу...");

        for(int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Main({i})");
        }


    }

    private static void DoSomethings(object sleepTime)
    {
        Console.WriteLine($"Задача #{Task.CurrentId} началась в потоке {Thread.CurrentThread.ManagedThreadId}");

        Thread.Sleep((int)sleepTime);

        Console.WriteLine($"         Задача #{Task.CurrentId} завершилась в потоке {Thread.CurrentThread.ManagedThreadId}");
    }

}