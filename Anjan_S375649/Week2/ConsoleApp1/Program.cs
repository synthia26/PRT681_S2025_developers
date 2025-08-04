// See https://aka.ms/new-console-template for more information
using PasswordGenerator;

Console.WriteLine("Hello, World!");


var pwd = new Password();
var Password = pwd.Next();
Console.WriteLine($"Generated Password: {Password}");

Console.WriteLine("Press any key to exit...");
Console.ReadKey();