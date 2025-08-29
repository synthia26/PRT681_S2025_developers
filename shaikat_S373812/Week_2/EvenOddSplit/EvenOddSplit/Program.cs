using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenOddSplit
{
    internal class Program
    {
        /*
         * Create two lists with integer data type, one for even numbers and one for odd numbers.
         * Loop from 0 - 20
         * if number is even, add to even list
         * if number is odd, add to odd list
         * print both lists
         * 
         * 
         */
        static void Main(string[] args)
        {
            List<int> evenNumbers = new List<int>();
            List<int> oddNumbers = new List<int>();

            for (int i = 0; i <= 20; i++)
            {
                if (i % 2 == 0)
                {
                    evenNumbers.Add(i);
                }
                else
                {
                    oddNumbers.Add(i);
                }
            }
            Console.WriteLine("Even Numbers:");
            foreach (var even in evenNumbers)
            {
                Console.Write($"{even} ");
            }
            Console.WriteLine();
            Console.WriteLine("Odd Numbers:");
            foreach (var odd in oddNumbers)
            {
                Console.Write($"{odd} ");
            }
        }
    }
}
