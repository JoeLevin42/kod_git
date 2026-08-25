


namespace EventConsumerWorker.Models;

public class WeatherReading
{
    public string Location { get; set; }
    public decimal TemperatureCelsius { get; set; }
    public int Humidity { get; set; }
    public DateTime Timestamp { get; set; }
}

