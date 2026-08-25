
using CatalogConsumer.Models;
using ConsumerCatalog.Data;
using System.Text.Json;

namespace ConsumerCatalog.Service;

public class ProccessorService
{
    private readonly ApplicationDbContext _context;
    public ProccessorService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<bool> ProccessUavAsync(string uavJson)
    {
        try
        {
            var uavObj = JsonSerializer.Deserialize<Uav>(uavJson);//one one

            if (uavObj == null) //simple validation
            {
                return false;
            }

            //logic rules come here

            _context.Uavs.Add(uavObj);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return false;
        }
    }


    public async Task<bool> ProccessHotileUnitAsync(string unitJson)
    {
        try
        {
            var unitObj = JsonSerializer.Deserialize<HostileUnit>(unitJson); //one -one
            if (unitObj == null)
            {
                return false;
            }

            //logic rules

            var uavParent = _context.Uavs
                .FirstOrDefault(e => e.model_id == unitObj.model_id);
            if (uavParent == null)
            {
                return false;
            }

            string threatBand; 

            switch (uavParent.max_range_km)
            {
                case < 50:
                    threatBand = "low";
                    break;
                case <= 200:
                    threatBand = "medium";
                    break;
                case > 200:
                    threatBand = "high";
                    break;
            }
            var proccesHostileObj = new HostileProccessed
            {
                unit_id = unitObj.unit_id,
                model_id = unitObj.model_id,
                operator_name = unitObj.operator_name,
                first_seen_date = unitObj.first_seen_date,
                status = unitObj.status,
                home_lat = unitObj.home_lat,
                home_lon = unitObj.home_lon,
                threat_band = threatBand
            };

            _context.HostileUnits.Add(proccesHostileObj);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return false;
        }
    }

    public async Task<bool> ProccessTrackAsync(string trackJson)
    {
        try
        {
            var trackObj = JsonSerializer.Deserialize<Track>(trackJson);
            if (trackObj == null)
            {
                return false;
            }

            //logic rule

            //--
            var proccesedTrack = new TrackProccessed
            {
                track_id = trackObj.track_id,
                unit_id = trackObj.unit_id,
                report_time = trackObj.report_time,
                latitude = trackObj.latitude,
                longitude = trackObj.longitude,
                altitude_m = trackObj.altitude_m,
                signal_strength = trackObj.signal_strength,
                sector_code = $"S{(int)trackObj.latitude}-{(int)trackObj.longitude}"
            };

            _context.TrackProccesseds.Add(proccesedTrack);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return false;
        }
    }

            
}