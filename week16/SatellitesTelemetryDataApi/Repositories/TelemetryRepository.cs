
using Microsoft.AspNetCore.Http.HttpResults;
using SatellitesTelemetryDataApi.Models;


namespace SatellitesTelemetryDataApi.Repositories;

public class TelemetryRepository : ITelemetryRepository
{
    private readonly List<TelemetryReport> _telemetryReports;
    private int _nextId;
    public TelemetryRepository()
    {
        _telemetryReports = new List<TelemetryReport>
{
    new TelemetryReport
    {
        Id = 1,
        SatelliteId = 1,
        BatteryPercent = 85,
        TemperatureCelsius = 18,
        SignalStrengthDb = -45,
        ReportedAt = DateTime.UtcNow.AddHours(-8),
        Status = "Normal"
    },
    new TelemetryReport
    {
        Id = 2,
        SatelliteId = 1,
        BatteryPercent = 73,
        TemperatureCelsius = 22,
        SignalStrengthDb = -52,
        ReportedAt = DateTime.UtcNow.AddHours(-6),
        Status = "Normal"
    },
    new TelemetryReport
    {
        Id = 3,
        SatelliteId = 2,
        BatteryPercent = 64,
        TemperatureCelsius = 10,
        SignalStrengthDb = -60,
        ReportedAt = DateTime.UtcNow.AddHours(-5),
        Status = "Normal"
    },
    new TelemetryReport
    {
        Id = 4,
        SatelliteId = 3,
        BatteryPercent = 92,
        TemperatureCelsius = -15,
        SignalStrengthDb = -40,
        ReportedAt = DateTime.UtcNow.AddHours(-4),
        Status = "Normal"
    },
    new TelemetryReport
    {
        Id = 5,
        SatelliteId = 4,
        BatteryPercent = 51,
        TemperatureCelsius = 35,
        SignalStrengthDb = -70,
        ReportedAt = DateTime.UtcNow.AddHours(-3),
        Status = "Normal"
    },
    new TelemetryReport
    {
        Id = 6,
        SatelliteId = 5,
        BatteryPercent = 39,
        TemperatureCelsius = 5,
        SignalStrengthDb = -80,
        ReportedAt = DateTime.UtcNow.AddHours(-2),
        Status = "Normal"
    },
    new TelemetryReport
    {
        Id = 7,
        SatelliteId = 6,
        BatteryPercent = 97,
        TemperatureCelsius = -8,
        SignalStrengthDb = -33,
        ReportedAt = DateTime.UtcNow.AddHours(-1),
        Status = "Normal"
    },
    new TelemetryReport
    {
        Id = 8,
        SatelliteId = 8,
        BatteryPercent = 68,
        TemperatureCelsius = 27,
        SignalStrengthDb = -58,
        ReportedAt = DateTime.UtcNow,
        Status = "Normal"
    }
};

        _nextId = 9;
    }

    public async Task<IEnumerable<TelemetryReport>> GetAllAsync()
    {
        await Task.Delay(10);
        return _telemetryReports;
    }
    public async Task<TelemetryReport?> GetByIdAsync(int id)
    {
        await Task.Delay(10);
        var sat = _telemetryReports.FirstOrDefault(t => t.Id == id);

        return sat;
    }
    public async Task<IEnumerable<TelemetryReport>> GetBySatelliteIdAsync(int satelliteId)
    {
        await Task.Delay(10);
        IEnumerable<TelemetryReport> satList = _telemetryReports.Where(t => t.SatelliteId == satelliteId);
        return satList;

    }
    public async Task<TelemetryReport?> CreateAsync(TelemetryReport report)
    {
        await Task.Delay(10);
        report.Id = _nextId++;
        _telemetryReports.Add(report);

        return report;
    }
}