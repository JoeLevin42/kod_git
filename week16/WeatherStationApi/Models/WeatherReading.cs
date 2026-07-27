namespace WeatherStationApi.Models;

public class WeatherReading
{
    public int Id { get; set; }
    public string StationName { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public double TemperatureCelsius { get; set; }
    public int HumidityPercent { get; set; }
    public double WindSpeedKmh { get; set; }
    public DateTime RecordedAt { get; set; }

    public WeatherReading() { }
}