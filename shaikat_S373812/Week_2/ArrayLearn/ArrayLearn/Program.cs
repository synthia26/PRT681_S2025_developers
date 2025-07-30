using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayLearn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[5];
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($"Enter number at index {i}: ");
                numbers[i] = Convert.ToInt32(Console.ReadLine());
            }
            //numbers[0] = 10;
            //numbers[1] = 20;
            //numbers[2] = 30;
            //numbers[3] = 40;
            //numbers[4] = 50;
            //Console.WriteLine($"{numbers[0]} {numbers[1]} {numbers[2]} {numbers[3]} {numbers[4]} ");
            foreach (int num in numbers)
            {
                Console.WriteLine(num);
            }
        }
    }
}
