using System;

class Shape {
    public virtual void Draw() {
        Console.WriteLine("Drawing a shape");
    }
}

class Circle : Shape {
    public override void Draw() {
        Console.WriteLine("Drawing a circle");
    }
}

class Program {
    static void Main() {
        Shape s = new Circle();
        s.Draw();
    }
}