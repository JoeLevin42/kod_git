using System.ComponentModel.DataAnnotations;

namespace AirportFlightLogApi.Models;

public class FlightLog
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Flight number is required")]
    [StringLength(10, MinimumLength = 3, ErrorMessage = "Flight number must be between 3 and 10 characters")]
    public string FlightNumber { get; set; } = string.Empty;

    [Required(ErrorMessage = "Airline is required")]
    [StringLength(50, ErrorMessage = "Aireline cannot excced 50 chars")]
    public string Airline { get; set; } = string.Empty;
    [Required(ErrorMessage = "Destination is required")]
    [StringLength(100,ErrorMessage = "Destination cannot exceed 100")]
    public string Destination { get; set; } = string.Empty;

    [Range(1,1000,ErrorMessage = "Passenger count must be between 1 to 1000")]
    public int PassengerCount { get; set; }

    [Required(ErrorMessage = "departure time is requierd")]
    public DateTime ScheduledDeparture { get; set; }
    public DateTime? ActualDeparture { get; set; }

    [StringLength(500,ErrorMessage = "Remarks cannot be more that 500 chars")]
    public string? Remarks { get; set; }
    public string Status { get; set; } = "Scheduled";
}