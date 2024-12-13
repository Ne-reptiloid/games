using System;

class Program
{
    static void BubbleSort(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            bool swapped = false;

            for (int j = 0; j < array.Length - 1 - i; j++)
            {
                if (array[j] > array[j + 1])
                {
                    Swap(ref array[j], ref array[j + 1]);
                    swapped = true;
                }
            }

            if (!swapped)
            {
                break; // Если за итерацию не было обменов, значит массив уже отсортирован
            }
        }
    }

    static void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    static void PrintArray(int[] array)
    {
        foreach (var item in array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    public static void Main()
    {
        int[] array = { 64, 6, 0, 12, 454422, 1, -100 };

        Console.WriteLine("Исходный массив:");
        PrintArray(array);

        BubbleSort(array);

        Console.WriteLine("Отсортированный массив:");
        PrintArray(array);

        Console.WriteLine("Нажмите любую клавишу для выхода...");
        Console.ReadKey(); // Ожидает нажатия любой клавиши
    }
    
}
