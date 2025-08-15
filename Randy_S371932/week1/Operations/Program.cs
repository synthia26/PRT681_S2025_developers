using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int age = 23;
            age++;
            age = age + 1;
            age += 10;
            Console.WriteLine(age);
            age--;
            age -= 11;
            age /= 2;
            Console.WriteLine(age);
            Console.ReadLine();
        }
    }
}
