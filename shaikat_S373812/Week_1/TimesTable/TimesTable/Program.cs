using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimesTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number to generate its times table: ");
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                Console.WriteLine($"Times table for {number}:");
                for (int i = 1; i <= 10; i++)
                {
                    //Console.WriteLine($"{number} x {i} = {number * i}");
                    Console.WriteLine("{0} * {1} = {2}",number,i,number*i);
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }
    }
}
