using System;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = { 1, 2, 3, 4, 5 };
        Console.WriteLine("Array values:");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}
