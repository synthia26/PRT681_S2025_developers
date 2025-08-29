using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a number:");
        int num = int.Parse(Console.ReadLine());

        string result = num % 2 == 0 ? "Even" : "Odd";
        Console.WriteLine($"The number is {result}.");
    }
}
