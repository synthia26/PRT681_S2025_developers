using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string textAge = "-23";
            int age = Convert.ToInt32(textAge);
            Console.WriteLine("Age: " + age);
            Console.WriteLine(int.MaxValue);
            Console.WriteLine(int.MinValue);

            string textBigNumber = "-9223372036854775807";
            long bigNumber = Convert.ToInt64(textBigNumber);
            Console.WriteLine("Big Number: " + bigNumber);
            Console.WriteLine(long.MaxValue);
            Console.WriteLine(long.MinValue);

            string textNegative = "-23.4";
            double negative = Convert.ToDouble(textNegative);
            Console.WriteLine("Negative Double: " + negative);
            Console.WriteLine(double.MaxValue);
            Console.WriteLine(double.MinValue);

            string textPrecision = "5.000001";
            float precision = Convert.ToSingle(textPrecision);
            Console.WriteLine("Precision Float: " + precision);
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
