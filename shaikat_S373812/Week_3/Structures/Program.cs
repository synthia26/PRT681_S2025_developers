using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Structures
{
    internal class Program
    {
        struct Person
        {
            public string name;
            public int age;
            public int birthMonth;

            public Person(string name, int age, int birthMonth)
            {
                this.name = name;
                this.age = age;
                this.birthMonth = birthMonth;
            }
        }
        static void Main(string[] args)
        {
            Person shaikat; ;
            shaikat.name = "Shaikat";
            shaikat.age = 25;

            Console.WriteLine($"{shaikat.name} is {shaikat.age} year's old!");

            Person alpha = ReturnPerson();
            Console.WriteLine($"{alpha.name} is {alpha.age} year's old and was born in month {alpha.birthMonth}.");

            

        }
        static Person ReturnPerson()
        {
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your age:");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your birth month:");
            int birthMonth = Convert.ToInt32(Console.ReadLine());


            return new Person(name,age,birthMonth);

        }
    }
}
