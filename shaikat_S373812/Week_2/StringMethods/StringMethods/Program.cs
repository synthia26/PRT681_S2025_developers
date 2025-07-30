using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();

            if (name != string.Empty)
            {
                Console.WriteLine($"Hello, {name}!");
            }
            else
            {
                Console.WriteLine("You didn't enter a name.");
            }
            string name1 = "Alpha";
            string name2 = "Alpha";
            if (name1.Equals(name2))
            {
                Console.WriteLine("The names are equal.");
            }
            else
            {
                Console.WriteLine("The names are not equal.");
            }

            if (!name.Equals(""))
            {
                Console.WriteLine($"Welcome, {name}!");
            }
            else
            {
                Console.WriteLine("No name provided.");
            }
            char[] chars = new char[] { 'A', 'l', 'p', 'h', 'a' };
            object nameObject = new string(chars);
            if (name1.Equals(nameObject))
            {
                Console.WriteLine("Same Names");
            }
            else
            {
                Console.WriteLine("Different!");
            }
        }
    }
}
