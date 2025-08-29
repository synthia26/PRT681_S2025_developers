using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetterAndSetter
{
    internal class Program
    {
        class Person
        {
            private string name;
            private int age;
            
            public string Name
            {
                get => name;
                set => name = value;
            }
            public int Age
            {
                get => age;
                set => age = value;
            }
            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }
        }
        static void Main(string[] args)
        {
            Person shaikat = new Person("Shaikat", 25);
            Console.WriteLine($"Name: {shaikat.Name}, Age: {shaikat.Age}");
            shaikat.Name = "Shaikat Barua";
            Console.WriteLine($"Name: {shaikat.Name}, Age: {shaikat.Age}");
        }
    }
}
