using System;

class Program
{
    static void Main(string[] args)
    {
        string input = "Hello, World!";
        Console.WriteLine($"Original: {input}");

        string substring = input.Substring(0, 5);
        Console.WriteLine($"Substring: {substring}");

        string concatenated = input + " How are you?";
        Console.WriteLine($"Concatenation: {concatenated}");
    }
}
