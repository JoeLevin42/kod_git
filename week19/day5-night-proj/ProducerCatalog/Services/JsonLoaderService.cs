

using System.Text.Json;

namespace ProducerCatalog.Services;

public class JsonLoaderService
{

    public List<T>? LoadFromJson<T>(string filePath)
    {
        try
        {
            var json = File.ReadAllText(filePath);

            var jsonObjList = JsonSerializer.Deserialize<List<T>>(json) ?? new(); //load all if null return emptylist

            return jsonObjList;
            
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }
}