
namespace SensorProducer.Models;


public class TrafficReading
{
    public string Location { get; set; }
    public int VehicleCount { get; set; }
    public DateTime Timestamp { get; set; }
}
