using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrianglCalculation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int angleCount = 3;
            int[] ints = new int[angleCount];
            int triangleSum = 0;
            Console.WriteLine("Enter the angles of the triangle:");
            for(int i = 0;i< angleCount; i++)
            {
                 triangleSum+= int.Parse(Console.ReadLine());
            }
           
            Console.WriteLine(triangleSum == 180 ? "Valid":"Invalid");
        }
    }
}
