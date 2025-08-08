using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Function
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreateAndPrintArray();
            //WelcomeMessage();
        }
        //static void WelcomeMessage()
        //{
        //    Console.WriteLine("Welcome to the Function Program!");
        //}
        static void CreateAndPrintArray()
        {
            int[] numbers = new int[3] { 1, 2, 3 };

            foreach (int number in numbers)
            {
                Console.Write($"{number} ");
            }
        }
    }
}
