

public struct Box
{
    public int a;
    public int b;
}
internal class Program
{

    private static void Main()
    {
      int a = 3 ; int b = 2;

        Box box;
        box.a = a ; box.b = b ;

        Task<int> task = new Task<int>(Calc, box);
        task.Start();

        Console.WriteLine($"Суммв чисел: {task.Result}");
        Console.WriteLine(new string('-', 80));

        Task<int> lambda = new Task<int>(() => Calc(a, 5));
        lambda.Start();
        Console.WriteLine($"Суммв чисел: {lambda.Result}");
        Console.WriteLine(new string('-', 80));

        Task<int> taskRun = Task<int>.Run<int>(() =>
        {
            int a1 = 5;
            int b1 = 5;
            return Calc(a1, b1) + Calc(a, b);
        });

        Console.WriteLine($"Суммв чисел: {taskRun.Result}");
        Console.WriteLine(new string('-', 80));


        Task.Run(() => ShowSelfParameters(1, false, 'c', "hello", 3.14, new object(), box, new Program(), taskRun));
        Console.ReadKey();
    }

   private static int Calc(object arg)
    {
        Box box = (Box)arg;
        return box.a + box.b;
    }

    private static int Calc(int a, int b)
    {
        return a + b;
    }

    private static void ShowSelfParameters(int a, bool b, char c, string d, double e, object f, Box box, Program program, dynamic something)
    {
        Console.WriteLine(new string('-', 80));

        Console.WriteLine(a);
        Console.WriteLine(b);
        Console.WriteLine(c);
        Console.WriteLine(d);
        Console.WriteLine(e);
        Console.WriteLine(f);
        Console.WriteLine(box.a + " " + box.b);
        Console.WriteLine(program.GetType().Name);
        Console.WriteLine(something);

        Console.WriteLine(new string('-', 80));
    }
}