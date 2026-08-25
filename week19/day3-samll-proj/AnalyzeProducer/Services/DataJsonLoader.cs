

using System.Text.Json;

namespace AnalyzeProducer.Services;

public class LoaderDataJson()
{

    public List<T>? LoadFromJson<T>(string filePath)
    {
        try
        {
            var jsonFile = File.ReadAllText(filePath);
            var jsonObjList = JsonSerializer.Deserialize<List<T>>(jsonFile) ?? new();

            return jsonObjList;
        }
        catch(JsonException ex)
        {
            return null;
        }            
    }
}