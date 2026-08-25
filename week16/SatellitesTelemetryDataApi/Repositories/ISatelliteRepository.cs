
using SatellitesTelemetryDataApi.Models;


namespace SatellitesTelemetryDataApi.Repositories;

public interface ISatelliteRepository
{
    public Task<IEnumerable<Satellite>> GetAllAsync();
    public Task<Satellite?> GetByIdAsync(int id);
    public Task<Satellite?> CreateAsync(Satellite satellite);
    public Task<bool> UpdateAsync(int id, Satellite satellite);
    public Task<bool> DeleteAsync(int id);
}