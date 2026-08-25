
using Confluent.Kafka;
using System.Text.Json;

namespace NightProducer.Services;

public class JsonLoaderService
{
    public List<T>? LoadFromJson<T>(string filePath)
    {
        try
        {
            var json = File.ReadAllText(filePath);
            if (json == null)
            {
                return null;
            }

            var jsonObjList = JsonSerializer.Deserialize<List<T>>(json);

            return jsonObjList;

        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine("File not found {ex}");
            return null;
        }
        catch (JsonException ex)
        {
            Console.WriteLine("Json problem!");
            return null;
        }
    }
}