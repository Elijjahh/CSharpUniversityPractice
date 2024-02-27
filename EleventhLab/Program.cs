using System;
using System.Collections.Generic;

namespace EleventhLab
{
    // Абстрактный базовый класс
    public abstract class Animal
    {
        public string Name;
        public int Age;
        public int Children;

        public Animal()
        {
            Name = "Unknown";
            Age = 0;
            Children = 0;
        }

        public Animal(string name, int age, int children)
        {
            Name = name;
            Age = age;
            Children = children;
        }

        public override string ToString()
        {
            return "Название: "
                + Name.ToString()
                + ", Возраст: "
                + Age.ToString()
                + ", Количество потомков: "
                + Children.ToString();
        }

        public abstract void ChangeCharacteristics(string name, int age, int children);
    }

    // Производные классы
    public class Mammal : Animal
    {
        public Mammal()
            : base() { }

        public Mammal(string name, int age, int children)
            : base(name, age, children) { }

        public override void ChangeCharacteristics(string name, int age, int children)
        {
            this.Name = name;
            this.Age = age;
            this.Children = children;
        }
    }

    public class Ungulate : Animal
    {
        public Ungulate()
            : base() { }

        public Ungulate(string name, int age, int children)
            : base(name, age, children) { }

        public override void ChangeCharacteristics(string name, int age, int children)
        {
            this.Name = name;
            this.Age = age;
            this.Children = children;
        }
    }

    public class Bird : Animal
    {
        public Bird()
            : base() { }

        public Bird(string name, int age, int children)
            : base(name, age, children) { }

        public override void ChangeCharacteristics(string name, int age, int children)
        {
            this.Name = name;
            this.Age = age;
            this.Children = children;
        }
    }

    // Класс, содержащий коллекцию объектов
    public class Zoo
    {
        private readonly List<Animal> animals;

        public Zoo()
        {
            animals = new List<Animal>();
        }

        public void AddAnimal(Animal animal)
        {
            animals.Add(animal);
        }

        public void RemoveAnimal(int index)
        {
            if (index >= 0 && index < animals.Count)
            {
                animals.RemoveAt(index);
            }
        }

        public void ChangeAnimalCharacteristics(int index, string name, int age, int children)
        {
            if (index >= 0 && index < animals.Count)
            {
                animals[index].ChangeCharacteristics(name, age, children);
            }
        }

        public void PrintAnimals()
        {
            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Console.InputEncoding = System.Text.Encoding.GetEncoding("utf-16");
            Zoo zoo = new();

            while (true)
            {
                Console.WriteLine(
                    "\nВыберите действие:"
                        + "\n1. Добавить животное в зоопарк"
                        + "\n2. Удалить животное из зоопарка"
                        + "\n3. Вывести информацию о животных в зоопарке"
                        + "\n4. Изменить характеристики животного"
                        + "\n5. Выход"
                );

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine(
                            "\nВыберите животное:"
                                + "\n1. млекопитающие"
                                + "\n2. парнокопытные"
                                + "\n3. птицы"
                        );
                        int inner_choice = int.Parse(Console.ReadLine());
                        switch (inner_choice)
                        {
                            case 1:
                                Mammal mammal = new("Новое млекопитающее", 1, 4);
                                zoo.AddAnimal(mammal);
                                Console.WriteLine("\nДобавлено новое млекопитающее");
                                Console.WriteLine(mammal.ToString());
                                break;
                            case 2:
                                Ungulate ungulate = new("Новое парнокопытное", 1, 1);
                                zoo.AddAnimal(ungulate);
                                Console.WriteLine("\nДобавлено новое парнокопытное");
                                Console.WriteLine(ungulate.ToString());
                                break;
                            case 3:
                                Bird bird = new("Новая птица", 1, 1);
                                zoo.AddAnimal(bird);
                                Console.WriteLine("\nДобавлена новая птица");
                                Console.WriteLine(bird.ToString());
                                break;
                        }
                        break;
                    case 2:
                        Console.WriteLine("\nВыберите индекс для удаления: ");
                        int index = int.Parse(Console.ReadLine());

                        zoo.RemoveAnimal(index);
                        Console.WriteLine("Животное удалено");
                        break;
                    case 3:
                        Console.WriteLine();
                        zoo.PrintAnimals();
                        break;
                    case 4:
                        Console.Write("\nВыберите индекс для изменения: ");
                        int changeIndex = int.Parse(Console.ReadLine());
                        Console.Write("\nНовое имя: ");
                        string newName = Console.ReadLine();
                        Console.Write("\nНовый возраст: ");
                        int newAge = int.Parse(Console.ReadLine());
                        Console.Write("\nНовое количество потомков: ");
                        int newChildren = int.Parse(Console.ReadLine());
                        Console.WriteLine();

                        zoo.ChangeAnimalCharacteristics(changeIndex, newName, newAge, newChildren);
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
        }
    }
}
