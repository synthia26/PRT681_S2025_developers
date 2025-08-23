using System;

interface IVehicle {
    void Drive();
}

class Bike : IVehicle {
    public void Drive() {
        Console.WriteLine("Bike is driving");
    }
}

class Program {
    static void Main() {
        IVehicle v = new Bike();
        v.Drive();
    }
}