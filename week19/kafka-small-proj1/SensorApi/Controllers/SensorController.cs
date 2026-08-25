using Microsoft.AspNetCore.Mvc;
using SensorApi.Services;
using SensorApi.Models;

namespace SensorApi.Controllers;

[ApiController]
[Route("[controller]")]
public class SensorController : ControllerBase
{
    private readonly KafkaConsumerService _cunsumerService;
    public SensorController(KafkaConsumerService cunsumerService)
    {
        _cunsumerService = cunsumerService;
    }
    [HttpGet]
    public ActionResult<Sensor> GetNextSensor()
    {
        var sensor = _cunsumerService.ConsumeNextSensor(TimeSpan.FromSeconds(5));

        if (sensor == null)
        {
            return NotFound(); 
        }

        return Ok(sensor);
    }
}