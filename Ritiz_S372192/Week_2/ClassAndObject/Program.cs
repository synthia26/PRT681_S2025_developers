using System;

class Student {
    public string Name { get; set; }
    public int Age { get; set; }

    public void PrintInfo() {
        Console.WriteLine($"Student: {Name}, Age: {Age}");
    }
}

class Program {
    static void Main() {
        Student s = new Student { Name = "Alice", Age = 21 };
        s.PrintInfo();
    }
}