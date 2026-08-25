
using Microsoft.AspNetCore.Http.HttpResults;
using SatellitesTelemetryDataApi.Models;



namespace SatellitesTelemetryDataApi.Repositories;

public interface ITelemetryRepository
{

    public Task<IEnumerable<TelemetryReport>> GetAllAsync();
    public Task<TelemetryReport?> GetByIdAsync(int id);
    public Task<IEnumerable<TelemetryReport>> GetBySatelliteIdAsync(int satelliteId);
    public Task<TelemetryReport?> CreateAsync(TelemetryReport report);
}