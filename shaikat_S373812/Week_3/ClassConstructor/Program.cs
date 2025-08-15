using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassConstructor
{
    internal class Program
    {
        class Person
        {
            public string Name;
            public int Age;

            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }

            public string ReturnDetails()
            {
                return $"{Name} is {Age} years old!";
            }
        }
        static void Main(string[] args)
        {

            Person shaikat = new Person("Shaikat", 30);
            //Console.WriteLine($"{shaikat.Name} is {shaikat.Age} years old!");
            Console.WriteLine(ReturnDetails(shaikat));
            Person alpha = new Person("Alpha", 25);
            Console.WriteLine(ReturnDetails(alpha));
            Person shanto = new Person("Shanto", 28);
            Console.WriteLine(shanto.ReturnDetails());
        }

        static string ReturnDetails(Person person)
        {
            return $"{person.Name} is {person.Age} years old!";
        }
    }
}
