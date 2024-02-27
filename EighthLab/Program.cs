using System;
using ArrayLibrary;

namespace EighthLab
{
    class Program
    {
        static void Main()
        {
            // Целочисленный массив
            int[] intArray = new int[5];
            ArrayMethods.FillIntArray(intArray, 1, 10);
            Console.WriteLine("Целочисленный массив: " + ArrayMethods.PrintArray(intArray));
            Console.WriteLine("Сумма элементов: " + ArrayMethods.Sum(intArray));
            Console.WriteLine("Произведение элементов: " + ArrayMethods.Multiply(intArray));
            Console.WriteLine(
                "Максимальный элемент: "
                    + ArrayMethods.MaxElement(intArray, out int maxIndex)
                    + " (индекс "
                    + maxIndex
                    + ")"
            );

            // Вещественный массив
            double[] doubleArray = new double[5];
            ArrayMethods.FillDoubleArray(doubleArray);
            Console.WriteLine("\nВещественный массив: " + ArrayMethods.PrintArray(doubleArray));
            Console.WriteLine("Сумма элементов: " + ArrayMethods.Sum(doubleArray));
            Console.WriteLine("Произведение элементов: " + ArrayMethods.Multiply(doubleArray));
            Console.WriteLine(
                "Максимальный элемент: "
                    + ArrayMethods.MaxElement(doubleArray, out int maxIndexDouble)
                    + " (индекс "
                    + maxIndexDouble
                    + ")"
            );

            // Строковый массив
            string[] stringArray = { "Длинная строка", "Короткая" };
            Console.WriteLine("\nСтроковый массив: " + ArrayMethods.PrintArray(stringArray));
            Console.WriteLine(
                "Максимальный элемент: "
                    + ArrayMethods.MaxElement(stringArray, out int maxIndexString)
                    + " (индекс "
                    + maxIndexString
                    + ")"
            );
        }
    }
}
