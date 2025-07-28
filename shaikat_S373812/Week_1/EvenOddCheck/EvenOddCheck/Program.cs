using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenOddCheck
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your Name : ");
            string name = Console.ReadLine();
            Console.WriteLine($"Hello {name}, welcome to the EvenOddCheck program!");
            Console.Write("Enter a number : ");
            int number = Convert.ToInt32(Console.ReadLine());
            if (number % 2 == 0)
            {
                Console.WriteLine("The number is even.");
            }
            else
            {
                Console.WriteLine("The number is odd.");
            }
            Console.Write("Enter your age : ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"{name}, you are {age} year's old!");
            //if(age>=19)
            //{
            //    Console.WriteLine("You are an adult.");
            //}
            //else
            //{
            //    Console.WriteLine("You are a minor.");
            //}
            if (age >=18 && age <= 25)
            {
                Console.WriteLine("You are between 18 and 25");
            }
            else if(age < 18)
            {
                Console.WriteLine("You are a minor.");
            }
            else
            {
                Console.WriteLine("You are an adult.");
            }


        }
    }
}
