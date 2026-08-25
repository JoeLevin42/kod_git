
namespace SensorProducer.Models;


public class ParkingReading
{
    public string Location { get; set; }
    public int AvailableSpots { get; set; }
    public int TotalSpots { get; set; }
    public DateTime Timestamp { get; set; }
}

