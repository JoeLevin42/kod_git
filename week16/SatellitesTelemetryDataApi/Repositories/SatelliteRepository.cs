
using SatellitesTelemetryDataApi.Models;

namespace SatellitesTelemetryDataApi.Repositories;

public class SatelliteRepository : ISatelliteRepository
{
    private readonly List<Satellite> _satellites;
    private int _nextId;

    public SatelliteRepository()
    {
        _satellites = new List<Satellite>
             {
                new Satellite
                {
                    Id = 1,
                    Name = "Hubble Explorer",
                    OrbitAltitudeKm = 540,
                    Status = "Active"
                },
                new Satellite
                {
                    Id = 2,
                    Name = "Aurora Monitor",
                    OrbitAltitudeKm = 850,
                    Status = "Standby"
                },
                new Satellite
                {
                    Id = 3,
                    Name = "Deep Space Observer",
                    OrbitAltitudeKm = 12000,
                    Status = "Active"
                },
                new Satellite
                {
                    Id = 4,
                    Name = "Weather Tracker",
                    OrbitAltitudeKm = 700,
                    Status = "Active"
                },
                new Satellite
                {
                    Id = 5,
                    Name = "Communication Relay",
                    OrbitAltitudeKm = 22000,
                    Status = "Standby"
                },
                new Satellite
                {
                    Id = 6,
                    Name = "Earth Scanner",
                    OrbitAltitudeKm = 1500,
                    Status = "Active"
                },
                new Satellite
                {
                    Id = 7,
                    Name = "Old Research Satellite",
                    OrbitAltitudeKm = 30000,
                    Status = "Decommissioned"
                },
                new Satellite
                {
                    Id = 8,
                    Name = "Navigation Satellite",
                    OrbitAltitudeKm = 20000,
                    Status = "Active"
                },
                new Satellite
                {
                    Id = 9,
                    Name = "Climate Observer",
                    OrbitAltitudeKm = 950,
                    Status = "Standby"
                },
                new Satellite
                {
                    Id = 10,
                    Name = "Military Recon Satellite",
                    OrbitAltitudeKm = 35000,
                    Status = "Decommissioned"
                }
            };
        _nextId = 11;


    }

    public async Task<IEnumerable<Satellite>> GetAllAsync()
    {

        await Task.Delay(10);
        return _satellites;
    }

    public async Task<Satellite?> GetByIdAsync(int id)
    {
        await Task.Delay(10);
        var sat = _satellites.FirstOrDefault(s => s.Id == id);

        return sat;

    }

    public async Task<Satellite?> CreateAsync(Satellite satellite) 
    {
        await Task.Delay(10);
        satellite.Id = _nextId++;
        _satellites.Add(satellite);
        return satellite;
    }

    public async Task<bool> UpdateAsync(int id, Satellite updatedSatellite)
    {
        await Task.Delay(10);

        var existsSat = _satellites.FirstOrDefault(s => s.Id == id);
        if (existsSat == null)
        {
            return false;
        }

        existsSat.Name = updatedSatellite.Name;
        existsSat.OrbitAltitudeKm = updatedSatellite.OrbitAltitudeKm;
        existsSat.Status = updatedSatellite.Status;

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        await Task.Delay(10);
        var sat = _satellites.FirstOrDefault(s => s.Id == id);
        if (sat == null)
        {
            return false;
        }

        _satellites.Remove(sat);
        return true;

    }

}

