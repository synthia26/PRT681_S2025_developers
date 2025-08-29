using System;
using System.Text.Json;
using JSON.Data;
using JSON.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace JSON
{
  internal class Program
  {
    static void Main(string[] args)
    {
      IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
      DataContextDapper dapper = new(config);

      // Computer myComputer = new()
      // {
      //   Motherboard = "Z700",
      //   HasWifi = true,
      //   HasLTE = false,
      //   ReleaseDate = DateTime.Now,
      //   Price = 934.99m,
      //   VideoCard = "RTX 3060"
      // };

      // string sql = @"INSERT INTO TutorialAppSchema.Computer (
      //   Motherboard,
      //   HasWifi,
      //   HasLTE,
      //   ReleaseDate,
      //   Price,
      //   VideoCard
      // ) VALUES ('" + myComputer.Motherboard
      //   + "','" + myComputer.HasWifi
      //   + "','" + myComputer.HasLTE
      //   + "','" + myComputer.ReleaseDate
      //   + "','" + myComputer.Price
      //   + "','" + myComputer.VideoCard
      // + "')\n";

      // File.WriteAllText("log.txt", sql);

      // using StreamWriter openFile = new("log.txt", append: true);
      // openFile.WriteLine(sql);
      // openFile.Close();

      string computersJson = File.ReadAllText("Computers.json");
      // Console.WriteLine(computersJson);

      JsonSerializerOptions options = new()
      {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
      };
      IEnumerable<Computer>? computersSystem = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Computer>>(computersJson, options);

      JsonSerializerSettings settings = new()
      {
        ContractResolver = new CamelCasePropertyNamesContractResolver()
      };

      IEnumerable<Computer>? computersNewtonSoft = JsonConvert.DeserializeObject<IEnumerable<Computer>>(computersJson);

      if (computersNewtonSoft != null)
      {
        foreach (Computer computer in computersNewtonSoft)
        {
          // Console.WriteLine(computer.Motherboard);
          string sql = @"INSERT INTO TutorialAppSchema.Computer (
            Motherboard,
            HasWifi,
            HasLTE,
            ReleaseDate,
            Price,
            VideoCard
          ) VALUES (@Motherboard, @HasWifi, @HasLTE, @ReleaseDate, @Price, @VideoCard)";

          dapper.ExecuteSql<Computer>(sql, computer);
        }
      }

      string computersCopyNewtonSoft = JsonConvert.SerializeObject(computersNewtonSoft, settings);
      File.WriteAllText("computersCopyNewtonSoft.txt", computersCopyNewtonSoft);

      string computersCopySystem = System.Text.Json.JsonSerializer.Serialize(computersSystem, options);
      File.WriteAllText("computersCopySystem.txt", computersCopySystem);
    }
  }
}