using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[] {50, 20, 30, 10, 40};
            Array.Sort(numbers);
            Array.Reverse(numbers);
            Console.WriteLine(Array.IndexOf(numbers, 100)!=-1?"Numaber found!":"Number not found!");
            Array.Clear(numbers, 0, 2); // Clear the first two elements
            Console.WriteLine("Sorted numbers:");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($"{numbers[i]} ");
            }
            Console.WriteLine();
            foreach (int number in numbers)
            {
                Console.Write($"{number} ");
            }
        }
    }
}
