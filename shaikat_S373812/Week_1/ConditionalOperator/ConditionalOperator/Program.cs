using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionalOperator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //condition ? trueValue : falseValue
            Console.Write("Enter your age: ");
            int age = Convert.ToInt32(Console.ReadLine());
            string result = age <= 0 ? "Invalid age":"Valid age";
            Console.WriteLine(result);
        }
    }
}
