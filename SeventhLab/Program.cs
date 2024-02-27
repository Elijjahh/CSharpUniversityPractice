using System;

namespace SeventhLab
{
    // Седьмое задание
    class Animal
    {
        private string name,
            type;
        private int averageWeightKg;

        public Animal()
        {
            this.name = "Elephant";
            this.type = "Elephants";
            this.averageWeightKg = 4000;
        }

        public Animal(string name, string type, int averageWeightKg)
        {
            this.name = name;
            this.type = type;
            this.averageWeightKg = averageWeightKg;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public int AverageWeightKg
        {
            get { return averageWeightKg; }
            set
            {
                if (value > 0)
                {
                    averageWeightKg = value;
                }
                else
                {
                    averageWeightKg = 0;
                }
            }
        }

        public void Log()
        {
            string output = string.Format(
                "Animal {0} from {1} weights {2}",
                name,
                type,
                averageWeightKg
            );
            Console.WriteLine(output);
        }

        public void Save()
        {
            string outputPath = @"animals.txt";
            string output = string.Format(
                "Animal {0} from {1} weights {2}",
                name,
                type,
                averageWeightKg
            );
            // Console.WriteLine(output);
            File.AppendAllText(outputPath, output);
        }

        public static Animal operator +(Animal m1, Animal m2)
        {
            if (m1.type == m2.type)
            {
                Animal m3 = new(m1.name, m1.type, m1.averageWeightKg + m2.averageWeightKg);
                return m3;
            }
            else
            {
                throw new Exception("Нельзя сложить животных разных типов.");
            }
        }

        public static bool operator <(Animal m1, Animal m2)
        {
            if (m1.type == m2.type)
            {
                return m1.averageWeightKg < m2.averageWeightKg;
            }
            else
            {
                throw new Exception("Нельзя сравнить животных разных типов.");
            }
        }

        public static bool operator >(Animal m1, Animal m2)
        {
            if (m1.type == m2.type)
            {
                return m1.averageWeightKg > m2.averageWeightKg;
            }
            else
            {
                throw new Exception("Нельзя сравнить животных разных типов.");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            // Создание экземпляров и использование методов
            Animal africanElephant = new();
            africanElephant.Log();

            Animal europeanElephant = new("European Elephant", "Elephants", 3000);
            europeanElephant.Save();

            // Использование свойств
            Animal dolphin = new("dolpin", "dolphins", 500);
            Console.WriteLine(dolphin.Name);
            dolphin.Name = "Dolphin";
            dolphin.Type = "Dolphins";
            dolphin.AverageWeightKg = -300;

            // Использование операторов
            Animal mixedElephant = africanElephant + europeanElephant;
            Console.WriteLine(mixedElephant.AverageWeightKg);
            Console.WriteLine(africanElephant > europeanElephant);
            Console.WriteLine(africanElephant < europeanElephant);

            // Ошибка
            Animal mixedAnimal = africanElephant + dolphin;
            Console.WriteLine(mixedAnimal.AverageWeightKg);
        }
    }
}
