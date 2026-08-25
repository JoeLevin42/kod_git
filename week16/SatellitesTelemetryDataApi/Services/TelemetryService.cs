using SatellitesTelemetryDataApi.Models;
using SatellitesTelemetryDataApi.Repositories;
using SatellitesTelemetryDataApi.Models;

namespace SatellitesTelemetryDataApi.Services;

public class TelemetryService : ITelemetryService
{ 
    private readonly ISatelliteRepository _satelliteRepo;
    private readonly ITelemetryRepository _telemetryRepo;
    public TelemetryService(ISatelliteRepository satelliteRepo , ITelemetryRepository telemetryRepo)
    {
        _satelliteRepo = satelliteRepo;
        _telemetryRepo = telemetryRepo;
    }
    public async Task<IEnumerable<TelemetryReport>> GetAllReportsAsync()
    {
        return await _telemetryRepo.GetAllAsync();
    }
    public async Task<TelemetryReport?> GetReportByIdAsync(int id)
    {
        var telemetryReport = await _telemetryRepo.GetByIdAsync(id);
        if (telemetryReport == null)
        {
            return null;
        }
        return  telemetryReport;
    }
    public async Task<IEnumerable<TelemetryReport>> GetReportsBySatelliteIdAsync(int satelliteId)
    {
        return await _telemetryRepo.GetBySatelliteIdAsync(satelliteId);
    }
    public async Task<TelemetryReport?> SubmitTelemetryAsync(TelemetryReportRequest request)

    {
        var sat = await _satelliteRepo.GetByIdAsync(request.SatelliteId);
        if (sat == null)
        {
            return null;
        }
        if (request.BatteryPercent < 10)
        {
            return null;
        }
        if (request.TemperatureCelsius < -50 || request.TemperatureCelsius > 60)
        {
            return null;
        }

        if (request.SignalStrengthDb < -100)
        {
            return null;
        }
        var report = new TelemetryReport
        {
            SatelliteId = request.SatelliteId,
            BatteryPercent = request.BatteryPercent,
            TemperatureCelsius = request.TemperatureCelsius,
            SignalStrengthDb = request.SignalStrengthDb,

            ReportedAt = DateTime.UtcNow,
            Status = "Normal"
        };

        await _telemetryRepo.CreateAsync(report);

        return  report;


    }
}
