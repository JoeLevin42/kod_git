using NightConsumer.Data;
using NightConsumer.Models;
using System.Text.Json;
namespace NightConsumer.Services;

public class Proccessor
{
    private readonly ApplicationDbContext _db;

    public Proccessor(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<bool> ProccessAnalysts(string json)
    {
        var jsonObj = JsonSerializer.Deserialize<Analysts>(json);

        if (jsonObj == null)
        {
            return false;
        }

        //if there is logic rules this is the place 

        _db.Analysts.Add(jsonObj);
        await _db.SaveChangesAsync();
        return true;
    }
    public async Task<bool> ProccessCalls(string json)
    {
        var jsonObj = JsonSerializer.Deserialize<Calls>(json);

        if (jsonObj == null)
        {
            return false;
        }

        //if there is logic rules this is the place 

        _db.Calls.Add(jsonObj);
        await _db.SaveChangesAsync();
        return true;
    }
        

}