using System;
using AutoMapper;
using ModelMapping.Models;

namespace ModelMapping
{
  internal class Program
  {
    static void Main(string[] args)
    {
      string computerJson = File.ReadAllText("ComputersSnake.json");
      Mapper mapper = new(new MapperConfiguration((cfg) =>
      {
        cfg.CreateMap<ComputerSnake, Computer>()
          .ForMember(
          destination => destination.ComputerId,
          options => options.MapFrom(source => source.computer_id)
          )
          .ForMember(
          destination => destination.CPUCores,
          options => options.MapFrom(source => source.cpu_cores)
          )
          .ForMember(
          destination => destination.HasLTE,
          options => options.MapFrom(source => source.has_lte)
          )
          .ForMember(
          destination => destination.HasWifi,
          options => options.MapFrom(source => source.has_wifi)
          )
          .ForMember(
          destination => destination.Motherboard,
          options => options.MapFrom(source => source.motherboard)
          )
          .ForMember(
          destination => destination.VideoCard,
          options => options.MapFrom(source => source.video_card)
          )
          .ForMember(
          destination => destination.ReleaseDate,
          options => options.MapFrom(source => source.release_date)
          )
          .ForMember(
          destination => destination.Price,
          options => options.MapFrom(source => source.price)
          );
      }));

      // IEnumerable<ComputerSnake>? computerSnakesSystem = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<ComputerSnake>>(computerJson);

      // if (computerSnakesSystem != null)
      // {
      //   IEnumerable<Computer> computerResult = mapper.Map<IEnumerable<Computer>>(computerSnakesSystem);
      //   foreach (Computer computer in computerResult)
      //   {
      //     Console.WriteLine(computer.Motherboard);
      //   }
      // }

      IEnumerable<Computer>? computerSystem = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Computer>>(computerJson);
      if (computerSystem != null)
      {
        foreach (Computer computer in computerSystem)
        {
          Console.WriteLine(computer.Motherboard);
        }
      }
    }
  }
}