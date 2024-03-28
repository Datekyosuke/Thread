internal class Program
{

    private static void Main()
    {
        Task task = new Task(new Action(Method));

        Console.WriteLine($"{task.Status}");

        task.Start();
        Console.WriteLine($"{task.Status}");
        Thread.Sleep( 1000 );

        Console.WriteLine($"{task.Status}");
        Thread.Sleep(2000);

        Console.WriteLine($"{task.Status}");
        Thread.Sleep(1000);

    }

    private static void Method()
    { 
        Thread.Sleep(2000);
    }
}