using System;

namespace ArrayLibrary
{
    public static class ArrayMethods
    {
        private static readonly Random random = new();

        public static void FillIntArray(int[] array, int min, int max)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(min, max + 1);
            }
        }

        public static void FillDoubleArray(double[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.NextDouble();
            }
        }

        public static int Sum(int[] array)
        {
            int sum = 0;
            foreach (int num in array)
            {
                sum += num;
            }
            return sum;
        }

        public static double Sum(double[] array)
        {
            double sum = 0;
            foreach (double num in array)
            {
                sum += num;
            }
            return sum;
        }

        public static int Multiply(int[] array)
        {
            int multiply = 1;
            foreach (int num in array)
            {
                multiply *= num;
            }
            return multiply;
        }

        public static double Multiply(double[] array)
        {
            double multiply = 1;
            foreach (double num in array)
            {
                multiply *= num;
            }
            return multiply;
        }

        public static int MaxElement(int[] array, out int index)
        {
            int max = array[0];
            index = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                    index = i;
                }
            }
            return max;
        }

        public static double MaxElement(double[] array, out int index)
        {
            double max = array[0];
            index = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                    index = i;
                }
            }
            return max;
        }

        public static string MaxElement(string[] array, out int index)
        {
            string max = array[0];
            index = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i].Length > max.Length)
                {
                    max = array[i];
                    index = i;
                }
            }
            return max;
        }

        public static string PrintArray(int[] array)
        {
            return string.Join(", ", array);
        }

        public static string PrintArray(double[] array)
        {
            return string.Join(", ", array);
        }

        public static string PrintArray(string[] array)
        {
            return string.Join(", ", array);
        }
    }
}
