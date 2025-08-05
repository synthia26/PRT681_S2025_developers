using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaOfTriangle
{
    internal class Program
    {
        /*
         * 
         * Ask user for width and height, store them
         * Create function to calculate the area
         * Function should calculate the area using: (width * height) / 2
         * Call in main and print out the area of  the triangle
         * 
         */
        static void Main(string[] args)
        {
            Console.WriteLine("Enter width:");
            int width = Convert.ToInt32(Console.ReadLine());
            int height = ReadInt("Enter height:");
            //Console.WriteLine(width);
            //Console.WriteLine(height);
            int result = CalcArea(width, height);
            Console.WriteLine($"The area of the triangle is: {result}");
        }

        static int ReadInt(string message)
        {
            Console.WriteLine(message);
            return Convert.ToInt32(Console.ReadLine());
        }
        static int CalcArea(int width, int height)
        {
            return (width * height) / 2;
        }
    }
}
