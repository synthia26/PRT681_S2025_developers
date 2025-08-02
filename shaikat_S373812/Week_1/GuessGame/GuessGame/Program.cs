using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            //GuessGame with While Loop();
            Console.Write("Enter Number_1: ");
            int number_1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Number_2: ");
            int number_2 = Convert.ToInt32(Console.ReadLine());
            Console.Write($"Enter your Guess: {number_1} * {number_2}: ");
            int userAnswer = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            /*
            while (userAnswer != number_1 * number_2)
            {
                Console.WriteLine("Wrong Guess! Try Again.");
                Console.Write("Enter your Guess: ");
                userAnswer = Convert.ToInt32(Console.ReadLine());
            }
            if(number_1 * number_2 == userAnswer)
            {
                Console.WriteLine("Congratulations! You guessed the correct answer.");
            }
            

            while(userAnswer != number_1 * number_2)
            {
                
                
                if(userAnswer != number_2 * number_1)
                {
                    Console.WriteLine("Wrong Guess! Try Again.");
                    Console.Write("Enter your Guess: ");
                    userAnswer = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                }
                
            }
            Console.WriteLine("Congratulations! You guessed the correct answer.");
            */
            // GuessGame with Do-While Loop
            do
            {
                Console.Write("Enter Number_1: ");
                int number_1 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Number_2: ");
                int number_2 = Convert.ToInt32(Console.ReadLine());
                Console.Write($"Enter your Guess: {number_1} * {number_2}: ");
                int userAnswer = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                while (userAnswer != number_1 * number_2)
                {
                    Console.WriteLine("Wrong Guess! Try Again.");
                    Console.Write("Enter your Guess: ");
                    userAnswer = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                }

                Console.WriteLine("Congratulations! You guessed the correct answer.");
            } while (true); // Loop indefinitely, can be modified to exit based on a condition.

        }
    }
}
