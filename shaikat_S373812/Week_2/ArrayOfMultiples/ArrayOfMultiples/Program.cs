using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayOfMultiples
{
    internal class Program
    {
        /*
         * Define and initialize two integers (num,length)
         * (7,5) -> [7, 14, 21, 28, 35]
         * Create int array with size length
         * loop trhough and insert the (loop counter * num) into the array
         * print the array
         */
        static void Main(string[] args)
        {
            int num = 7;
            int lenght = 5;
            int[] result = new int[lenght];
            for (int i = 1,counter = 0; i <= result.Length;i++,counter++)
            {
                result[counter] = i * num;
            }
            foreach (var item in result)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
    }
}
