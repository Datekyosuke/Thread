internal class Program
{
    private static void Main()
    {
        CalculateAnsShowAsync(5).GetAwaiter().GetResult();
        Console.ReadKey();
    }
    private static ValueTask CalculateAnsShowAsync(int ceiling)
    {
        if(ceiling < 0) { return new ValueTask(); }
        else
        {
            return new ValueTask(Task.Run(() =>
            {
                Calculator(ceiling);
            }));
        }

    }

    private static void Calculator(int ceiling)
    {
        int sum = 0;
        for (int i = 0; i < ceiling; i++)
            sum += i;
        Console.WriteLine($"Результат - {sum}. Найден в задаче #{Task.CurrentId}, в потоке #{Thread.CurrentThread.ManagedThreadId}");
    }
}