using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncParam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Sum(10,20));
            int num1 = ReadInt("Enter Number 1");
            //Console.WriteLine(num1);
            int num2 = ReadInt("Enter Number 2");
            Console.WriteLine(Sum(num1,num2));
            string name = ReadString("Enter your name");
            Console.WriteLine($"Hello {name}");
            int age = ReadInt("Enter your age");
            Console.WriteLine($"You are {age} years old");
            string details = UserDetails(name, age);
            Console.WriteLine(details);
        }
        static string UserDetails(string name, int age)
        {
            return $"Hello I'm: {name}, and I'm: {age}";
        }
        static int ReadInt(string message)
        {
            Console.Write($"{message}:");
            return Convert.ToInt32(Console.ReadLine());
        }
        static string ReadString(string message)
        {
            Console.Write($"{message}:");
            return Console.ReadLine();
        }
        static int Sum(int a, int b)
        {
            return a + b;
        }
    }
}
