using System;

class Program
{
    static int GetStepsToOne(int n)
    {
        if (n <= 0) throw new ArgumentException("Число должно быть положительным.");

        int steps = 0;

        while (n != 1)
        {
            if (n % 2 == 0)
                n /= 2; // Если n чётное, делим на 2.
            else
                n = 3 * n + 1; // Если n нечётное, умножаем на 3 и прибавляем 1.

            steps++;
        }

        return steps;
    }

    public static void Main()
    {
        Console.WriteLine("Введите положительное целое число:");
        string input = Console.ReadLine();

        try
        {
            int number = int.Parse(input);
            int result = GetStepsToOne(number);
            Console.WriteLine($"Для числа {number} требуется {result} шагов для достижения единицы.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка ввода. Введено неверное значение.");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
        Console.WriteLine("Нажмите любую клавишу для выхода...");
        Console.ReadKey(); // Ожидает нажатия любой клавиши
    }
}
