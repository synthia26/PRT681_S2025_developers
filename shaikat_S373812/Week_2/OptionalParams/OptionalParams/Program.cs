using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionalParams
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int result1 = Add(5,10);
            Console.WriteLine(result1);
        }
        static int Add(int a, int b = 0, int c = 0)
        {
            return a + b + c;
        }
    }
}
