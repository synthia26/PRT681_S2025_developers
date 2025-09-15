// ==========================================
// API 4: Weather API
// Demonstrates query parameters and data filtering
// ==========================================

using Microsoft.AspNetCore.Mvc;

namespace WeatherAPI.Controllers
{
    public class WeatherData
    {
        public string City { get; set; } = string.Empty;
        public double Temperature { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Humidity { get; set; }
        public DateTime Date { get; set; }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        // Sample weather data
        private static readonly List<WeatherData> _weatherData = new List<WeatherData>
        {
            new WeatherData { City = "New York", Temperature = 22.5, Description = "Sunny", Humidity = 65, Date = DateTime.Today },
            new WeatherData { City = "London", Temperature = 18.0, Description = "Cloudy", Humidity = 78, Date = DateTime.Today },
            new WeatherData { City = "Tokyo", Temperature = 25.3, Description = "Partly Cloudy", Humidity = 72, Date = DateTime.Today },
            new WeatherData { City = "Sydney", Temperature = 28.1, Description = "Clear", Humidity = 58, Date = DateTime.Today },
            new WeatherData { City = "Paris", Temperature = 20.7, Description = "Rainy", Humidity = 85, Date = DateTime.Today }
        };

        [HttpGet]
        public IActionResult GetAllWeather()
        {
            return Ok(_weatherData);
        }

        [HttpGet("{city}")]
        public IActionResult GetWeatherByCity(string city)
        {
            var weather = _weatherData.FirstOrDefault(w => 
                w.City.Equals(city, StringComparison.OrdinalIgnoreCase));
            
            if (weather == null)
                return NotFound(new { Message = $"Weather data for {city} not found" });

            return Ok(weather);
        }

        [HttpGet("search")]
        public IActionResult SearchWeather([FromQuery] double? minTemp, [FromQuery] double? maxTemp, [FromQuery] string? description)
        {
            var filteredWeather = _weatherData.AsQueryable();

            if (minTemp.HasValue)
                filteredWeather = filteredWeather.Where(w => w.Temperature >= minTemp.Value);

            if (maxTemp.HasValue)
                filteredWeather = filteredWeather.Where(w => w.Temperature <= maxTemp.Value);

            if (!string.IsNullOrWhiteSpace(description))
                filteredWeather = filteredWeather.Where(w => 
                    w.Description.Contains(description, StringComparison.OrdinalIgnoreCase));

            return Ok(filteredWeather.ToList());
        }
    }
}