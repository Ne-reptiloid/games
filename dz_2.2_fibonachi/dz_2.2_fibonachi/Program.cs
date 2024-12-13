using System;
using System.Diagnostics;

class Program
{
    public static int FibonacciRecursive(int n)
    {
        if (n <= 1)
            return n;

        return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
    }

    public static int FibonacciIterative(int n)
    {
        if (n <= 1)
            return n;

        int prev = 0, curr = 1;
        for (int i = 2; i <= n; i++)
        {
            int next = prev + curr;
            prev = curr;
            curr = next;
        }

        return curr;
    }

    public static void ComparePerformance(int n)
    {
        Stopwatch sw = new Stopwatch();

        sw.Start();
        int recursiveResult = FibonacciRecursive(n);
        sw.Stop();
        TimeSpan recursiveTime = sw.Elapsed;

        sw.Reset();

        sw.Start();
        int iterativeResult = FibonacciIterative(n);
        sw.Stop();
        TimeSpan iterativeTime = sw.Elapsed;

        Console.WriteLine($"n = {n}:");
        Console.WriteLine($"Рекурсивный метод: {recursiveTime.TotalMilliseconds} мс");
        Console.WriteLine($"Итеративный метод: {iterativeTime.TotalMilliseconds} мс");
        Console.WriteLine();
    }

    public static void Main(string[] args)
    {
        for (int n = 30; n <= 40; n += 2)
        {
            ComparePerformance(n);
        }

        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}
