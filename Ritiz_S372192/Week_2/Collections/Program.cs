using System;
using System.Collections.Generic;

class Program {
    static void Main() {
        List<string> names = new List<string> { "Alice", "Bob", "Charlie" };
        names.Add("Diana");
        foreach (var name in names) Console.WriteLine(name);

        Dictionary<int, string> students = new Dictionary<int, string>();
        students.Add(1, "Alice");
        students.Add(2, "Bob");
        Console.WriteLine($"Student with ID 1: {students[1]}");
    }
}