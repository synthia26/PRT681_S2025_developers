using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = 20,
                y = 30,
                z = x + y;
            z = 90;
            Console.WriteLine(z);
            //Console.WriteLine("Hello, World!");
            //int number_1 = 42;
            //int number_2 = 58;
            //int number = number_1 + number_2;
            //long number = 900L ;
            //Console.WriteLine(number);
            //Console.WriteLine(number);
            double negativeNumber = -3.14;
            Console.WriteLine(negativeNumber);
            string name = "Shaikat";
            char initial = 'S'; // So for single character, use char type and use single quotes.
            Console.WriteLine(name);
            Console.WriteLine(initial);
            Console.WriteLine("My Name is : "+name);
            //Console.ReadLine();
            //Converting string to number;
            string stringAge = "25";
            int age = Convert.ToInt32(stringAge);
            Console.WriteLine("My age is: " + age);
            //Console.ReadLine();
            // Boolean Value
            bool value = true;
            value = false;
            Console.WriteLine("Boolean Value: " + value);
            Console.ReadLine();

        }
    }
}
