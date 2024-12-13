using System;

class Program
{
    static void Main()
    {
        // Ввод коэффициентов
        Console.Write("Введите коэффициент a: ");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите коэффициент b: ");
        double b = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите коэффициент c: ");
        double c = Convert.ToDouble(Console.ReadLine());

        if (a == 0)
        {
            if (b == 0)
            {
                if (c == 0)
                {
                    Console.WriteLine("Бесконечное множество решений.");
                }
                else
                {
                    Console.WriteLine("Нет решений.");
                }
            }
            else
            {
                // Линейное уравнение bx + c = 0
                double x = -c / b;
                Console.WriteLine($"Одно решение: {x}");
            }
        }
        else
        {
            // Дискриминант
            double D = b * b - 4 * a * c;

            if (D > 0)
            {
                // Два различных действительных корня
                double x1 = (-b + Math.Sqrt(D)) / (2 * a);
                double x2 = (-b - Math.Sqrt(D)) / (2 * a);
                Console.WriteLine($"Два решения: {x1} и {x2}");
            }
            else if (D == 0)
            {
                // Один корень
                double x = -b / (2 * a);
                Console.WriteLine($"Одно решение: {x}");
            }
            else
            {
                // Нет действительных корней
                Console.WriteLine("Нет решений.");
            }
        }

        // Добавленная строка для удержания окна открытым
        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}