using System;
using System.Text.RegularExpressions;
using Namespaces.Models;

namespace Namespaces
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Computer myComputer = new()
      {
        Motherboard = "Z690",
        HasWifi = true,
        HasLTE = false,
        ReleaseDate = DateTime.Now,
        Price = 943.87m,
        VideoCard = "RTX 2060"
      };

      Console.WriteLine(myComputer.Motherboard);
    }
  }
}