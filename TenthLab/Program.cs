using System;

namespace TenthLab
{
    // Десятое задание
    class Animal
    {
        public string Name;
        public int Age { get; set; }

        public Animal()
        {
            Name = "Unknown";
            Age = 0;
        }

        public Animal(string name)
        {
            Name = name;
            Age = 0;
        }

        public virtual void MakeSound()
        {
            Console.WriteLine("The animal makes a sound");
        }
    }

    class Mammal : Animal
    {
        public int NumberOfLegs;
        public int NumberOfChildren { get; set; }

        public Mammal()
            : base()
        {
            NumberOfLegs = 4;
            NumberOfChildren = 1;
        }

        public Mammal(string name, int legs, int children)
            : base(name)
        {
            NumberOfLegs = legs;
            NumberOfChildren = children;
        }

        public override void MakeSound()
        {
            Console.WriteLine("The mammal makes a sound");
        }
    }

    class Ungulate : Animal
    {
        public bool Hooves;
        public bool Hair { get; set; }

        public Ungulate()
            : base()
        {
            Hooves = true;
            Hair = true;
        }

        public Ungulate(string name, bool hooves, bool hair)
            : base(name)
        {
            Hooves = hooves;
            Hair = hair;
        }

        public override void MakeSound()
        {
            Console.WriteLine("The ungulate makes a sound");
        }
    }

    class Bird : Animal
    {
        public string FeatherColor;
        public bool CanFly { get; set; }

        public Bird()
            : base()
        {
            FeatherColor = "Unknown";
            CanFly = true;
        }

        public Bird(string name, string color, bool canFly)
            : base(name)
        {
            FeatherColor = color;
            CanFly = canFly;
        }

        public override void MakeSound()
        {
            Console.WriteLine("The bird makes a sound");
        }
    }

    class Program
    {
        static void Main()
        {
            Animal[] animals = new Animal[4];
            animals[0] = new Mammal("Dog", 4, 6);
            animals[1] = new Ungulate("Horse", true, true);
            animals[2] = new Bird("Parrot", "Green", true);
            animals[3] = new Animal("Unknown");

            foreach (var animal in animals)
            {
                Console.WriteLine($"Name: {animal.Name}, Age: {animal.Age}");
                animal.MakeSound();
                Console.WriteLine();
            }
        }
    }
}
