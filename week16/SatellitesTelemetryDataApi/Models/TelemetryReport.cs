using System.ComponentModel.DataAnnotations;

namespace SatellitesTelemetryDataApi.Models;

public class TelemetryReport
{
    public int Id { get; set; }

    [Required(ErrorMessage = "This is required")]
    public int SatelliteId { get; set; }

    [Required(ErrorMessage = "This is required")]
    [Range(0, 100, ErrorMessage = "This is have to be between 0 to 100")]
    public int BatteryPercent { get; set; }

    [Required(ErrorMessage = "This is required")]
    [Range(-100, 100, ErrorMessage = "This is have to be between -100 to 100")]
    public int TemperatureCelsius { get; set; }

    [Required(ErrorMessage = "This is required")]
    [Range(-120, 0, ErrorMessage = "This is have to be between -120 to 0")]
    public int SignalStrengthDb { get; set; }
    public DateTime ReportedAt { get; set; }
    public string Status { get; set; } = "normal";

}