using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordChecker
{
    internal class Program
    {
        /*
         * Ask user to enter a password, and store.
         * Ask user to enter password again and store.
         * Check if they are both containing something.
         * If so, check if they are the same.
         *          If they are the same, print "Password is valid".
         *          If they are not the same, print "Passwords do not match".
         *     If they are empty, print "Please enter a password".
         */
        static void Main(string[] args)
        {
            Console.WriteLine("Enter password: ");
            string password = Console.ReadLine();
            Console.WriteLine("Enter password again: ");
            string passwordC = Console.ReadLine();
            Console.Write("========================\n");
            Console.WriteLine(password);
            Console.WriteLine(passwordC);
            while (true)
            {
                if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(passwordC))
                {
                    Console.WriteLine("Please enter a password");
                    break;
                }
                else if (password.Equals(passwordC))
                {
                    Console.WriteLine("Password is valid");
                    break;
                }
                else
                {
                    Console.WriteLine("Passwords do not match");
                    break;
                }
            }
        }
    }
}
