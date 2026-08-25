using SensorProducer.Models;
using System.Text.Json;
namespace SensorProducer.Services;

public class DataLoaderService
{
    public DataLoaderService()
    {
    }
      

    public List<ParkingReading>? LoadParkingJson(string filePath)
    {
        try
        {

            var jsonFile = File.ReadAllText(filePath);

            var jsonObjList = JsonSerializer.Deserialize<List<ParkingReading>>(jsonFile) ?? new();

            return jsonObjList;
        }
        catch (JsonException ex)
        {
            return null;
        }
    }

    public List<TrafficReading>? LoadTrafficReadingJson(string filePath)
    {
        try
        {

            var jsonFile = File.ReadAllText(filePath);

            var jsonObjList = JsonSerializer.Deserialize<List<TrafficReading>>(jsonFile) ?? new();

            return jsonObjList;
        }
        catch (JsonException ex)
        {
            return null;
        }
    }
    public List<WeatherReading>? LoadWeatherReadingJson(string filePath)
    {
        try
        {

            var jsonFile = File.ReadAllText(filePath);

            var jsonObjList = JsonSerializer.Deserialize<List<WeatherReading>>(jsonFile) ?? new();

            return jsonObjList;
        }
        catch (JsonException ex)
        {
            return null;
        }
    }




}