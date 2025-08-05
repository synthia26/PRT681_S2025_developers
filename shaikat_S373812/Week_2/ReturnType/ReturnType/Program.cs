using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReturnType
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = ReturnName();
            PrintName();
            Console.WriteLine(Add());
        }
        static string ReturnName()
        {
            return "John Doe";
        }
        static void PrintName()
        {
            //string name = ReturnName();
            Console.WriteLine(ReturnName());
        }
        static int Add()
        {
            return 5 + 5;
        }
    }
}
