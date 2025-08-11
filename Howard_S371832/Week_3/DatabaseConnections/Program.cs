using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Numerics;
using DatabaseConnections.Models;
using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;
using DatabaseConnections.Data;

namespace DatabaseConnections
{
  public class Program
  {
    public static void Main(string[] args)
    {
      DataContextDapper dapper = new();

      string sqlCommand = "SELECT GETDATE()";

      DateTime rightNow = dapper.LoadDataSingle<DateTime>(sqlCommand);

      // Console.WriteLine(rightNow.ToString());

      Computer myComputer = new()
      {
        Motherboard = "Z690",
        HasWifi = true,
        HasLTE = false,
        ReleaseDate = DateTime.Now,
        Price = 943.87m,
        VideoCard = "RTX 2060"
      };

      // string sql = @"INSERT INTO TutorialAppSchema.Computer (
      //   Motherboard,
      //   HasWifi,
      //   HasLTE,
      //   ReleaseDate,
      //   Price,
      //   VideoCard
      // ) VALUES (@Motherboard, @HasWifi, @HasLTE, @ReleaseDate, @Price, @VideoCard)";

      // Console.WriteLine("Executing parameterised query...");

      // int result = dapper.ExecuteSqlWithRowCount(sql, myComputer);
      // // bool result = dapper.ExecuteSql(sql, myComputer);

      // Console.WriteLine(result);

      string sqlSelect = @"
      SELECT 
        Motherboard,
        HasWifi,
        HasLTE,
        ReleaseDate,
        Price,
        VideoCard
      FROM TutorialAppSchema.Computer
      ";

      IEnumerable<Computer> computers = dapper.LoadData<Computer>(sqlSelect);
      foreach (Computer singleComputer in computers)
      {
        Console.WriteLine(
          singleComputer.Motherboard
          + ", " + singleComputer.HasWifi
          + ", " + singleComputer.HasLTE
          + ", " + singleComputer.ReleaseDate
          + ", " + singleComputer.Price
          + ", " + singleComputer.VideoCard
        );
      }
    }
  }
}