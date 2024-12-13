using System;
using System.Diagnostics;

class Program
{
    public static long FactorialRecursive(int n)
    {
        if (n == 0 || n == 1)
            return 1;

        return n * FactorialRecursive(n - 1);
    }

    public static long FactorialIterative(int n)
    {
        long result = 1;
        for (int i = 2; i <= n; i++)
            result *= i;

        return result;
    }

    public static void ComparePerformance(int n)
    {
        Stopwatch sw = new Stopwatch();

        sw.Start();
        long recursiveResult = FactorialRecursive(n);
        sw.Stop();
        TimeSpan recursiveTime = sw.Elapsed;

        sw.Reset();

        sw.Start();
        long iterativeResult = FactorialIterative(n);
        sw.Stop();
        TimeSpan iterativeTime = sw.Elapsed;

        Console.WriteLine($"n = {n}:");
        Console.WriteLine($"Рекурсивный метод: {recursiveTime.TotalMilliseconds} мс");
        Console.WriteLine($"Итеративный метод: {iterativeTime.TotalMilliseconds} мс");
        Console.WriteLine();
    }

    public static void Main(string[] args)
    {
        for (int n = 10; n <= 20; n += 2)
        {
            ComparePerformance(n);
        }

        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }


}
