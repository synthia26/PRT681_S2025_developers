using System;
using FileReadAndWrite.Data;
using FileReadAndWrite.Models;
using Microsoft.Extensions.Configuration;

namespace FileReadAndWrite
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Computer myComputer = new()
      {
        Motherboard = "Z700",
        HasWifi = true,
        HasLTE = false,
        ReleaseDate = DateTime.Now,
        Price = 934.99m,
        VideoCard = "RTX 3060"
      };

      string sql = @"INSERT INTO TutorialAppSchema.Computer (
        Motherboard,
        HasWifi,
        HasLTE,
        ReleaseDate,
        Price,
        VideoCard
      ) VALUES ('" + myComputer.Motherboard
        + "','" + myComputer.HasWifi
        + "','" + myComputer.HasLTE
        + "','" + myComputer.ReleaseDate
        + "','" + myComputer.Price
        + "','" + myComputer.VideoCard
      + "')\n";

      File.WriteAllText("log.txt", sql);

      using StreamWriter openFile = new("log.txt", append: true);
      openFile.WriteLine(sql);
      openFile.Close();

      string fileText = File.ReadAllText("log.txt");
      Console.WriteLine(fileText);
    }
  }
}