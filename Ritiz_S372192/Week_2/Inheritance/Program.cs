using System;

class Animal {
    public void Speak() {
        Console.WriteLine("Animal makes a sound");
    }
}

class Dog : Animal {
    public void Bark() {
        Console.WriteLine("Dog barks");
    }
}

class Program {
    static void Main() {
        Dog d = new Dog();
        d.Speak();
        d.Bark();
    }
}