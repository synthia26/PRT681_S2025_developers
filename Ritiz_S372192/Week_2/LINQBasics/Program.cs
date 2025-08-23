using System;
using System.Linq;
using System.Collections.Generic;

class Program {
    static void Main() {
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
        var evens = numbers.Where(n => n % 2 == 0);

        Console.WriteLine("Even Numbers:");
        foreach (var n in evens) Console.WriteLine(n);
    }
}