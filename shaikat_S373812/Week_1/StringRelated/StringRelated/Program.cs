using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringRelated
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string speech = "He said,\"Alpha wait\"!";

            string path = "C:\\Users\\CoffeNCode\\Desktop\\C# Course";
            //verbatim string verbatimPath = @"C:\Users\CoffeNCode\Desktop\C# Course";
            path = @"C:\\Users\\CoffeNCode\\Desktop\\C# Course"+"\n";
            Console.WriteLine(speech);
            Console.Write(path);
            Console.WriteLine(@"Hello ""SomeONe""");
            Console.Write("\n");

            //string formatting

            string name = "Shaikat";
            int age = 20;
            Console.WriteLine("Name: "+name);
            Console.WriteLine("Age: " + age);

            Console.WriteLine("Name: " + name + "\nAge: " + age);

            Console.WriteLine("Your name is: "+name + ", and your age is: "+age);
        }
    }
}
