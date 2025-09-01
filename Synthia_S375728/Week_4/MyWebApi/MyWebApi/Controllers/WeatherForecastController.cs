using Microsoft.AspNetCore.Mvc;

namespace MyWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<WeatherForecast> forecasts = new List<WeatherForecast>
        {
            // Example data
            new WeatherForecast { Date = DateOnly.FromDateTime(DateTime.Now), TemperatureC = 25, Summary = "Sunny" }
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return forecasts;
        }

        [HttpPut("{index}")]
        public IActionResult Put(int index, [FromBody] WeatherForecast updatedForecast)
        {
            if (index < 0 || index >= forecasts.Count)
                return NotFound();

            forecasts[index] = updatedForecast;
            return NoContent();
        }

        [HttpDelete("{index}")]
        public IActionResult Delete(int index)
        {
            if (index < 0 || index >= forecasts.Count)
                return NotFound();

            forecasts.RemoveAt(index);
            return NoContent();
        }
    }
}
