using System.ComponentModel.DataAnnotations;

namespace SatellitesTelemetryDataApi.Models;

public class Satellite
{
    public int Id { get; set; }

    [Required(ErrorMessage = "this is required")]
    [StringLength(100 , ErrorMessage = "The max is 100 chars")]
    public string Name { get; set; }
    [Required(ErrorMessage = "this is required")]
    [Range(200,40000 , ErrorMessage = "The range can be between 200 - 4000")]
    public int OrbitAltitudeKm { get; set; }

    [Required(ErrorMessage = "this is required")]
    [RegularExpression("^Active|Standby|Decommissioned$")]
    public string Status { get; set; }
}