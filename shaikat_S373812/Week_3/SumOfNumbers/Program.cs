using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOfNumbers
{
    internal class Program
    {

        /*
         * Create and intialize int array of numbers.
         * Create a function SumOfNumbers with int ruturn type.
         * int array param.
         * Functioin should return total of all numbers.
         * Call in main and output total.
         * extra: check array length and return -1 if empty.
         * check return in main and output message.
         * do we need to return -1, how else can we handle it?
         */
        static void Main(string[] args)
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };

            Console.WriteLine("Sum of numbers: " + SumOfNumbers(numbers));
        }

        static int SumOfNumbers(int[] num)
        {
            if (num.Length > 0)
            {
                int total = 0;

                foreach (var i in num)
                {
                    total += i;
                }
                return total;

            }
            
            return -1; // Return -1 if the array is empty
        }
    }
}
