using SatellitesTelemetryDataApi.Models;
using SatellitesTelemetryDataApi.Repositories;

namespace SatellitesTelemetryDataApi.Services;

public interface ITelemetryService
{
    public Task<IEnumerable<TelemetryReport>> GetAllReportsAsync();
    public Task<TelemetryReport?> GetReportByIdAsync(int id);
    Task<IEnumerable<TelemetryReport>> GetReportsBySatelliteIdAsync(int satelliteId);
    public Task<TelemetryReport> SubmitTelemetryAsync(TelemetryReportRequest request);
}
