using System;
using System.Collections;

namespace EleventhLab
{
    // Абстрактный базовый класс
    public abstract class Animal : IComparable<Animal>, ICloneable
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

        public int CompareTo(Animal animal)
        {
            return this.Age.CompareTo(animal.Age);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    class AnimalComparer : IComparer<Animal>
    {
        public int Compare(Animal a1, Animal a2)
        {
            if (a1.Children > a2.Children)
                return 1;
            else if (a1.Children < a2.Children)
                return -1;
            else
                return 0;
        }
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
    public class Zoo : ICloneable, IEnumerable
    {
        public List<Animal> animals;

        public Zoo()
        {
            animals = new List<Animal>();
        }

        public Zoo(List<Animal> animals)
        {
            this.animals = animals;
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

        public override string ToString()
        {
            string text = "";
            foreach (Animal animal in animals)
            {
                text += animal.ToString() + "; ";
            }
            return text;
        }

        // public object Clone()
        // {
        //     return this.MemberwiseClone();
        // }

        public object Clone()
        {
            List<Animal> newAnimals = new();
            foreach (Animal animal in animals)
            {
                newAnimals.Add(animal.Clone() as Animal);
            }
            return new Zoo(newAnimals);
        }

        public IEnumerator GetEnumerator()
        {
            return animals.GetEnumerator();
        }
    }

    class Program
    {
        static void Main()
        {
            static void DemoIComparable()
            {
                Animal a1 = new Mammal("Лошадь", 5, 1);
                Animal a2 = new Ungulate("Коза", 3, 3);
                Animal a3 = new Bird("Орел", 10, 2);
                Animal[] animals = new Animal[] { a1, a2, a3 };

                Array.Sort(animals);
                foreach (Animal animal in animals)
                {
                    Console.WriteLine("{0} - {1} - {2}", animal.Name, animal.Age, animal.Children);
                }
                Console.WriteLine();
            }

            static void DemoIComparer()
            {
                Animal a1 = new Mammal("Лошадь", 5, 1);
                Animal a2 = new Ungulate("Коза", 3, 3);
                Animal a3 = new Bird("Орел", 10, 2);
                Animal[] animals = new Animal[] { a1, a2, a3 };

                Array.Sort(animals, new AnimalComparer());

                foreach (Animal animal in animals)
                {
                    Console.WriteLine("{0} - {1} - {2}", animal.Name, animal.Age, animal.Children);
                }
                Console.WriteLine();
            }

            static void DemoICloneable()
            {
                Animal a1 = new Mammal("Лошадь", 5, 1);
                Animal a2 = new Ungulate("Коза", 3, 3);
                Animal a3 = new Bird("Орел", 10, 2);
                List<Animal> animals = new() { a1, a2, a3 };
                List<Animal> animals2 = new() { a1, a3, a2 };
                Zoo zoo = new(animals);
                Zoo zoo2 = zoo.Clone() as Zoo;
                zoo2.animals = animals2;

                Console.WriteLine(zoo);
                Console.WriteLine(zoo2);
                Console.WriteLine();
            }

            static void DemoIEnumerable()
            {
                Animal a1 = new Mammal("Лошадь", 5, 1);
                Animal a2 = new Ungulate("Коза", 3, 3);
                Animal a3 = new Bird("Орел", 10, 2);
                List<Animal> animals = new() { a1, a2, a3 };
                Zoo zoo = new(animals);

                foreach (Animal animal in zoo)
                {
                    Console.WriteLine(animal);
                }
                Console.WriteLine();
            }

            DemoIComparable();
            DemoIComparer();
            DemoICloneable();
            DemoIEnumerable();
        }
    }
}
