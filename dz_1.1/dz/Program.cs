using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите число: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 2; i <= n; i++)
        {
            if (IsPrime(i))
                Console.WriteLine(i);
        }

        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }

    static bool IsPrime(int number)
    {
        if (number < 2) return false;

        for (int j = 2; j * j <= number; j++)
        {
            if (number % j == 0)
                return false;
        }

        return true;
    }
}
