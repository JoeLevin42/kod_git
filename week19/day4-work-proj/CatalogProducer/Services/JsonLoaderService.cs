
using System.Text.Json;

namespace CatalogProducer.Services;

public class JsonLoaderService
{
    public List<T>? LoadFromJson<T>(string filePath)
    {
        try
        {
            var json = File.ReadAllText(filePath);

            var jsonObjList = JsonSerializer.Deserialize<List<T>>(json) ?? new();

            return jsonObjList;

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }
}