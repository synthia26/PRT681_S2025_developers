using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = 10;
            number++;
            Console.WriteLine(number);
            number += 1;
            number += 10;
            Console.WriteLine(number);
            number-=9;
            Console.WriteLine(number);
            double d = Convert.ToDouble(number) / 2;
            Console.WriteLine(d);
            double ground = 25;
            ground /= 10;
            Console.WriteLine(ground);
            string name = "Shaikat";
            name += " is Proramming";
            Console.WriteLine(name);
            int i = 0;
            //++i;
            //i++;
            //Console.WriteLine(++i);
            //Console.WriteLine(i++);
            Console.WriteLine("This is remainder of 1000%90 :"+1000%90);
            const double  vat  = 12.5;
            int balance = 1000;
            Console.WriteLine(vat);
            Console.WriteLine("So the vat is : "+(balance*(vat/100D)));
            const double percentVat = vat/ 100D;
            Console.WriteLine("So the vat is : "+(balance*percentVat));
            const string version = "B1.0.0";
            Console.ReadLine();
        }
    }
}
