using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            for(int i = 0; i < 10; i++)
            {
                //Console.WriteLine($"Current value of i: {i}");
                Console.WriteLine("Hello Alpha");
            }
            for(int i = 0; i < 10; i+=2)
            {
                Console.WriteLine($"Current value of i: {i}");
            }
            */
            //while Loops
            int i = 0;
            while (i < 10)
            {
                //Console.WriteLine($"{i}");
                Console.WriteLine(i);
                i++;
            }
        }
    }
}
