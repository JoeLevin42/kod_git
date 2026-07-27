using Microsoft.AspNetCore.Mvc;
using WeatherStationApi.Models;
using WeatherStationApi;

namespace WeatherStationApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WatherReadingsController : ControllerBase
{
    private static readonly List<WeatherReading> _reading = new()
    {
    new WeatherReading {
        Id = 1,
        StationName = "Alpha",
        Location = "North",
        TemperatureCelsius = 22.5,
        HumidityPercent = 65,
        WindSpeedKmh = 12.3,
        RecordedAt = DateTime.UtcNow.AddHours(-2)
    },
      new WeatherReading {
        Id = 2,
        StationName = "Beta",
        Location = "Sotuh",
        TemperatureCelsius = 28.1,
        HumidityPercent = 72,
        WindSpeedKmh = 8.7,
        RecordedAt = DateTime.UtcNow.AddHours(-1)
    },
        new WeatherReading {
        Id = 3,
        StationName = "Gamma",
        Location = "East",
        TemperatureCelsius = 19.8,
        HumidityPercent = 58,
        WindSpeedKmh = 15.2,
        RecordedAt = DateTime.UtcNow.AddHours(-30)
    },
        new WeatherReading {
        Id = 4,
        StationName = "Delta",
        Location = "West",
        TemperatureCelsius = 25.3,
        HumidityPercent = 68,
        WindSpeedKmh = 10.1,
        RecordedAt = DateTime.UtcNow.AddHours(-15)
    },
        new WeatherReading {
        Id = 5,
        StationName = "Epsilon",
        Location = "North",
        TemperatureCelsius = 21.7,
        HumidityPercent = 61,
        WindSpeedKmh = 13.5,
        RecordedAt = DateTime.UtcNow.AddHours(-5)
    }

    };

    [HttpGet]
    public ActionResult<IEnumerable<WeatherReading>> GetAllReading()
    {
        return Ok(_reading);
    }

    [HttpGet("{id}")]
    public ActionResult<WeatherReading> GetReadingById(int id)
    {
        var reading = _reading.FirstOrDefault(r => r.Id == id);

        if (reading == null)
        {
            return NotFound();
        }
        return Ok(reading);
    }


}