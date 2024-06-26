﻿internal class Program
{
    private static Random random = new Random();
    private static void Main()
    {
        TaskFactory taskFactory = new TaskFactory();

        Task<double> t1 = taskFactory.StartNew(() => { return Calculate(1); });
        Task<double> t2 = taskFactory.StartNew(() => { return Calculate(2); });
        Task<double> t3 = taskFactory.StartNew(() => { return Calculate(3); });
        Task<double> t4 = taskFactory.StartNew(() => { return Calculate(4); });
        Task<double> t5 = taskFactory.StartNew(() => { return Calculate(5); });

        taskFactory.ContinueWhenAll(new Task[] {t1, t2, t2, t3, t4, t5}, completedeTask =>
        {
            double sum = 0.0;
            foreach (Task<double> task in completedeTask)
            {
                sum += task.Result;
            }
            Console.WriteLine($"Результат вычисления задач: {sum:N}");
        });
        Console.ReadKey();
    }

    private static double Calculate(int x)
    {
        double res = 0.0;

        for (int i = 0; i < 10; i++)
        {
            res += (i * random.Next(1, x) / (x * 2) * x);
        }

        return res;
    }

}