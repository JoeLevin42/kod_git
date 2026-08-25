using System.ComponentModel.DataAnnotations;

namespace VehicleFleetRegistry.Models;


public class Vehicle
{
    [Required(ErrorMessage = "Id is required")]
    public int Id { get; set; }
    [Required(ErrorMessage = "The Registation number is required")]
    [StringLength(15, MinimumLength = 5, ErrorMessage = "The length have to be between 5 - 15")]
    public string RegistrationNum { get; set; }

    [Required(ErrorMessage = "The vecihle type is required")]
    [StringLength(50, ErrorMessage = "The length of the type can me max 50 chars")]
    public string VecihleType { get; set; }

    [Required(ErrorMessage = "Status is required")]
    [RegularExpression("^Available|In-Use|Maintenance|Decommissioned$")]
    public string Status { get; set; }

    [StringLength(100, ErrorMessage = "the assigneDriver can be max 100 chars")]
    public string? AssigendDriver { get; set; }

    [StringLength(200, ErrorMessage = "The location can be max 200 chars")]
    public string? Location { get; set; }

    [Required(ErrorMessage = "The Mileage is required")]
    [Range(0, 500000, ErrorMessage = "The range have to be 0 - 500000")]
    public int Mileage { get; set; }
}