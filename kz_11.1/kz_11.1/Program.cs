using System;
using System.Diagnostics;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        // Создаем объект StringBuilder для хранения данных
        var sb = new StringBuilder();

        // Добавляем заголовок
        sb.AppendLine("x\tsin(x)");

        // Шаг изменения x
        double step = 0.1;

        for (double x = 0; x <= 1; x += step)
        {
            // Вычисление значения функции sin(x)
            double sinX = Math.Sin(x);

            // Форматируем строку и добавляем её в StringBuilder
            sb.AppendFormat("{0}\t{1}\n", x.ToString("F2"), sinX.ToString("F4"));
        }

        // Записываем данные в файл f.txt
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "f.txt");
        File.WriteAllText(filePath, sb.ToString());

        // Открываем созданный файл
        Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });

        Console.WriteLine("Таблица значений записана в файл 'f.txt' и открыт.");
    }
}