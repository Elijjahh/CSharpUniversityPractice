using System;

namespace NinthLab
{
    // Девятое задание
    public class Set
    {
        private int[] Elements;
        public int Count;

        // Конструктор без параметров
        public Set()
        {
            Console.Write("Введите количество элементов множества: ");
            int n = int.Parse(Console.ReadLine());
            Elements = new int[n];
            Count = Elements.Length;
            Fill();
        }

        // Конструктор с одним параметром
        public Set(int[] array)
        {
            Elements = array;
            Count = Elements.Length;
        }

        // Метод заполнения значений элементов множества
        public void Fill()
        {
            for (int i = 0; i < Elements.Length; i++)
            {
                Console.Write("Введите элемент множества: ");
                Elements[i] = int.Parse(Console.ReadLine());
            }
        }

        // Метод поиска индекса значения в множестве
        public int IndexOf(int value)
        {
            for (int i = 0; i < Elements.Length; i++)
            {
                if (Elements[i] == value)
                {
                    return i;
                }
            }
            return -1;
        }

        // Метод вывода элементов множества на экран
        public void ShowSet()
        {
            Console.WriteLine("Элементы множества: " + string.Join(", ", Elements));
        }

        // Метод добавления нового элемента в множество
        public void Add(int newElement)
        {
            Array.Resize(ref Elements, Elements.Length + 1);
            Elements[^1] = newElement;
            Count++;
        }

        // Перегрузка операции ++
        public static Set operator ++(Set set1)
        {
            for (int i = 0; i < set1.Elements.Length; i++)
            {
                set1.Elements[i]++;
            }
            return set1;
        }

        // Перегрузка операции +
        public static Set operator +(Set set1, Set set2)
        {
            IEnumerable<int> query =
                from planet in set1.Elements.Union(set2.Elements)
                select planet;
            return new Set(query.ToArray());
        }

        // Перегрузка операции *
        public static Set operator *(Set set1, Set set2)
        {
            IEnumerable<int> query =
                from planet in set1.Elements.Intersect(set2.Elements)
                select planet;
            return new Set(query.ToArray());
        }

        // Перегрузка операции /
        public static Set operator /(Set set1, Set set2)
        {
            IEnumerable<int> query =
                from planet in set1.Elements.Except(set2.Elements)
                select planet;
            return new Set(query.ToArray());
        }

        // Перегрузка операции <
        public static bool operator <(Set set1, Set set2)
        {
            return set1.Count < set2.Count;
        }

        // Перегрузка операции >
        public static bool operator >(Set set1, Set set2)
        {
            return set1.Count > set2.Count;
        }

        public override string ToString()
        {
            string text = "";
            foreach (int elem in Elements)
            {
                text += elem.ToString() + ", ";
            }
            return text;
        }

        // Индексатор для доступа к отдельным значениям поля Elements
        public int this[int index]
        {
            get { return Elements[index]; }
            set { Elements[index] = value; }
        }
    }

    class Program
    {
        static void Main()
        {
            Set set1 = new(new int[] { 1, 2, 3 });
            Set set2 = new();

            // Console.WriteLine(set1.IndexOf(3));

            // set2.ShowSet();
            // set2.Add(5);
            // set2.ShowSet();
            // set2++;
            // set2.ShowSet();
            Console.WriteLine(set1);
            Console.WriteLine(set2);
            Console.WriteLine(set1 + set2);
            Console.WriteLine(set1 * set2);
            Console.WriteLine(set1 / set2);
            // Console.WriteLine(set1 > set2);
            // Console.WriteLine(set1 < set2);
            // Console.WriteLine(set2[0]);
        }
    }
}
