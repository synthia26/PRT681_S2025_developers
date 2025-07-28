using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the First Number: ");
            int firstNumber = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the Second Number: ");
            int secondNumber = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the Multiplication: ");
            int multiplication = Convert.ToInt32(Console.ReadLine());
            if (firstNumber * secondNumber == multiplication)
            {
                Console.WriteLine("Correct! The multiplication is valid.");
            }
            Console.WriteLine("Incorrect! The multiplication is not valid.");
        }
    }
}
