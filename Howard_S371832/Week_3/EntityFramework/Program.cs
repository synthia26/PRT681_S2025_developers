using System;
using System.Text.RegularExpressions;
using EntityFramework.Data;
using EntityFramework.Models;
using Microsoft.Extensions.Configuration;

namespace EntityFramework
{
  internal class Program
  {
    static void Main(string[] args)
    {
      IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

      DataContextDapper dapper = new(config);
      DataContextEF entityFramework = new(config);

      // Computer myComputer = new()
      // {
      //   Motherboard = "Z700",
      //   HasWifi = true,
      //   HasLTE = false,
      //   ReleaseDate = DateTime.Now,
      //   Price = 934.99m,
      //   VideoCard = "RTX 3060"
      // };

      // entityFramework.Add(myComputer); 
      // entityFramework.SaveChanges();

      IEnumerable<Computer>? computers = entityFramework.Computer?.ToList<Computer>();

      if (computers != null)
      {
        foreach (Computer singleComputer in computers)
        {
          Console.WriteLine(singleComputer.Motherboard);
        }
      }
    }
  }
}