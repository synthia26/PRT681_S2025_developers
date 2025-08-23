using System;

class Car {
    public string Brand { get; set; }
    public int Year { get; set; }

    public Car(string brand, int year) {
        Brand = brand;
        Year = year;
    }

    public void Display() {
        Console.WriteLine($"{Brand} - {Year}");
    }
}

class Program {
    static void Main() {
        Car car = new Car("Toyota", 2022);
        car.Display();
    }
}