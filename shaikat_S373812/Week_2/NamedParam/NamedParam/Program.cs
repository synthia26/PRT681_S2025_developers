using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamedParam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintDetails("Shaikat", 27, "4/8, Duke Street, Stuart Park, NT-0820");
            string gameName = "Hades";
            string gameType = "Roguelike";
            int gameYear = 2020;
            GameDetails(type: gameType, name: gameName, year: gameYear);
        }
        static void PrintDetails(string name, int age = 0, string city = "Unknown")
        {
            Console.WriteLine($"Name: {name},\nAge: {age},\nCity: {city}");
        }
        static void GameDetails(string name,string type,int year)
        {
            Console.WriteLine($"{name} is {type} GAME, released in {year}");
        }
    }
}
