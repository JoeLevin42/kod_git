using CatalogConsumer.Data;
using CatalogConsumer.Models;
using CatalogConsumer.Services;
using System.Text.Json;


namespace CatalogConsumer.Services;

public class Proccessor
{
    private readonly ApplicationDbContext _db;
    public Proccessor(ApplicationDbContext db)
    {
        _db = db;
    }
    public async Task<bool?> ProccessUavAsync(string json)
    {
        var jsonObj = JsonSerializer.Deserialize<Uav>(json);
        //here u can to proccess the objects

        if (jsonObj == null)
        {
            return null;
        }

        _db.Uavs.Add(jsonObj);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool?> ProccessHostileUnitAsync(string json)
    {
        var jsonObj = JsonSerializer.Deserialize<HostileUnit>(json);

        if (jsonObj == null)
        {
            return false;
        }

        var check = _db.Uavs
            .FirstOrDefault(e => e.model_id == jsonObj.model_id);
        string threatBand = "default";
        switch (check.max_range_km)
        {
            case < 50:
                threatBand = "low";
                break;

            case <= 200:
                threatBand = "medium";
                break;

            default:
                threatBand = "high";
                break;
        }

        var hostileProccessed = new HostileProccessed
        {
            unit_id = jsonObj.unit_id,
            model_id = jsonObj.model_id,
            operator_name = jsonObj.operator_name,
            first_seen_date = jsonObj.first_seen_date,
            status = jsonObj.status,
            home_lat = jsonObj.home_lat,
            home_lon = jsonObj.home_lon,
            threat_band = threatBand
        };

        _db.HostileUnits.Add(hostileProccessed);
        await _db.SaveChangesAsync();
        return true;
    }



    public async Task<bool?> ProccessTrackAsync(string json)
    {

        var jsonObj = JsonSerializer.Deserialize<Track>(json);

        if (jsonObj == null)
        {
            return false;
        }

        _db.Tracks.Add(jsonObj);
        await _db.SaveChangesAsync();
        return true;
    }
}



