using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a number:");
        string input = Console.ReadLine();
        if (int.TryParse(input, out int result))
        {
            Console.WriteLine($"You entered: {result}");
        }
        else
        {
            Console.WriteLine("Invalid number.");
        }
    }
}
