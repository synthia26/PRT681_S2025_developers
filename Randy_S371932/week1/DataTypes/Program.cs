using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int age = 23;
            Console.WriteLine("Age: " + age);
            Console.WriteLine(int.MaxValue);
            Console.WriteLine(int.MinValue);

            long bigNumber = -9223372036854775807L;
            Console.WriteLine("Big Number: " + bigNumber);
            Console.WriteLine(long.MaxValue);
            Console.WriteLine(long.MinValue);

            double negative = -23.4;
            Console.WriteLine("Negative Double: " + negative);
            Console.WriteLine(double.MaxValue);
            Console.WriteLine(double.MinValue);

            float procision = 5.000001F;
            Console.WriteLine("Precision Float: " + procision);
            Console.WriteLine(float.MaxValue);
            Console.WriteLine(float.MinValue);

            decimal money = 15.67M;
            Console.WriteLine("Money: " + money);
            Console.WriteLine(decimal.MaxValue);
            Console.WriteLine(decimal.MinValue);

            Console.ReadLine();
        }
    }
}
