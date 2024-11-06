using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    internal class Program5
    {
        public abstract class Animal
        {
            public string _name;
            public int _weight;
            public abstract void makeSound();
            public abstract void print();
        }
        public class Cat : Animal
        {
            public override void makeSound()
            {
                Console.WriteLine("Meoooooooooooooooooooow");
            }
            public override void print()
            {
                Console.WriteLine($"This cat's name is { _name}");
                Console.WriteLine($"This cat's weight is {_weight} lbs");
            }
        }
        public class Dog : Animal
        {
            public override void makeSound()
            {
                Console.WriteLine("Wooooooooooooooooooooof");
            }
            public override void print()
            {
                Console.WriteLine($"This dog's name is {_name}");
                Console.WriteLine($"This dog's weight is {_weight} lbs");
            }
        }
        static void Main(string[] args)
        {
            Cat Misty = new Cat();
            Misty._name = "Misty";
            Misty._weight = 8;

            Cat Luna = new Cat();
            Luna._name = "Luna";
            Luna._weight = 12;

            Dog Haley = new Dog();
            Haley._name = "Haley";
            Haley._weight = 31;

            Dog Daisy = new Dog();
            Daisy._name = "Daisy";
            Daisy._weight = 87;

            Misty.makeSound();
            Misty.print();

            Luna.makeSound();
            Luna.print();

            Haley.makeSound();
            Haley.print();

            Daisy.makeSound();
            Daisy.print();
        }
    }
}
