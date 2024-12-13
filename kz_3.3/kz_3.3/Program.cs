using System;

public class ComplexNumber
{
    private double realPart;
    private double imaginaryPart;

    public ComplexNumber(double real, double imag)
    {
        this.realPart = real;
        this.imaginaryPart = imag;
    }

    public double RealPart => realPart;
    public double ImaginaryPart => imaginaryPart;

    public override string ToString() =>
        $"({realPart}, {imaginaryPart})";

    #region Основные арифметические операции

    public static ComplexNumber operator +(ComplexNumber z1, ComplexNumber z2)
    {
        return new ComplexNumber(z1.realPart + z2.realPart,
                                 z1.imaginaryPart + z2.imaginaryPart);
    }

    public static ComplexNumber operator -(ComplexNumber z1, ComplexNumber z2)
    {
        return new ComplexNumber(z1.realPart - z2.realPart,
                                 z1.imaginaryPart - z2.imaginaryPart);
    }

    public static ComplexNumber operator *(ComplexNumber z1, ComplexNumber z2)
    {
        var ac = z1.realPart * z2.realPart;
        var bd = z1.imaginaryPart * z2.imaginaryPart;
        var ad = z1.realPart * z2.imaginaryPart;
        var bc = z1.imaginaryPart * z2.realPart;

        return new ComplexNumber(ac - bd, ad + bc);
    }

    public static ComplexNumber operator /(ComplexNumber z1, ComplexNumber z2)
    {
        if (z2.realPart == 0 && z2.imaginaryPart == 0)
            throw new DivideByZeroException("Деление на ноль!");

        var denominator = Math.Pow(z2.Magnitude(), 2); // |z2|^2
        var realNumerator = z1.realPart * z2.realPart + z1.imaginaryPart * z2.imaginaryPart;
        var imagNumerator = z1.imaginaryPart * z2.realPart - z1.realPart * z2.imaginaryPart;

        return new ComplexNumber(realNumerator / denominator, imagNumerator / denominator);
    }

    #endregion

    #region Дополнительные методы

    public double Magnitude()
    {
        return Math.Sqrt(Math.Pow(realPart, 2) + Math.Pow(imaginaryPart, 2));
    }

    public double AngleInRadians()
    {
        return Math.Atan2(imaginaryPart, realPart);
    }

    public double AngleInDegrees()
    {
        return Math.Atan2(imaginaryPart, realPart) * 180 / Math.PI;
    }

    public ComplexNumber Power(int exponent)
    {
        if (exponent == 0)
            return new ComplexNumber(1, 0);

        var magnitude = Math.Pow(Magnitude(), exponent);
        var angle = AngleInRadians() * exponent;

        return FromPolar(magnitude, angle);
    }

    public ComplexNumber Sqrt()
    {
        var magnitude = Math.Sqrt(Magnitude());
        var angle = AngleInRadians() / 2;

        return FromPolar(magnitude, angle);
    }

    private static ComplexNumber FromPolar(double magnitude, double angle)
    {
        var real = magnitude * Math.Cos(angle);
        var imag = magnitude * Math.Sin(angle);

        return new ComplexNumber(real, imag);
    }

    #endregion
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите действительную часть первого комплексного числа:");
        double real1 = ReadDouble();

        Console.WriteLine("Введите мнимую часть первого комплексного числа:");
        double imag1 = ReadDouble();

        Console.WriteLine("Введите действительную часть второго комплексного числа:");
        double real2 = ReadDouble();

        Console.WriteLine("Введите мнимую часть второго комплексного числа:");
        double imag2 = ReadDouble();

        var z1 = new ComplexNumber(real1, imag1);
        var z2 = new ComplexNumber(real2, imag2);

        Console.WriteLine("\nОперации над введенными комплексными числами:");
        Console.WriteLine($"Комплексное число 1: {z1}");
        Console.WriteLine($"Комплексное число 2: {z2}\n");

        Console.WriteLine($"Сложение: {z1} + {z2} = {z1 + z2}");
        Console.WriteLine($"Вычитание: {z1} - {z2} = {z1 - z2}");
        Console.WriteLine($"Умножение: {z1} * {z2} = {z1 * z2}");
        Console.WriteLine($"Деление: {z1} / {z2} = {z1 / z2}");

        Console.WriteLine($"\nМодуль комплексного числа {z1}: {z1.Magnitude()}");
        Console.WriteLine($"Угол в радианах: {z1.AngleInRadians()}");
        Console.WriteLine($"Угол в градусах: {z1.AngleInDegrees()}");

        Console.WriteLine($"\nКвадратный корень из {z1}: {z1.Sqrt()}");
        Console.WriteLine($"Возведение в квадрат: {z1.Power(2)}");

        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }

    static double ReadDouble()
    {
        while (true)
        {
            if (double.TryParse(Console.ReadLine(), out double value))
                return value;

            Console.WriteLine("Ошибка ввода. Введите действительное число:");
        }
    }
}


