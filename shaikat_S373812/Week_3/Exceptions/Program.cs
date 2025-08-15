using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {

                try
                {
                    Console.Write("Enter a number: ");
                    int num = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(num);
                    break;
                    
                }
                catch (OverflowException)
                {
                    Console.WriteLine("The number is too big!");
                }
                catch (FormatException)
                {
                    Console.WriteLine("The input is not a valid number!");
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("You did not enter anything!");
                }
                catch (Exception)
                {
                    Console.WriteLine("Something has went Wrong!");
                }
                
            }
        }
    }
}
