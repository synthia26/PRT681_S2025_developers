using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = "Shaikat";
            string age = "25";
            Console.WriteLine("Your Name is {0}, you're {1} now!",name,age);
            Console.WriteLine($"Your Name is {name}, you're {age} now!");
            string test = string.Concat("Your Name is ", name, ", you're ", age, " now!");
            Console.WriteLine(test);
            string[] names =new string[] {"Alpha ", "Beta ", "Gamma "};
            Console.WriteLine(string.Concat(names));
        }
    }
}
