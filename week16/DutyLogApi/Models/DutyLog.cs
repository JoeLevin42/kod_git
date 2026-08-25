using System.ComponentModel.DataAnnotations;

namespace DutyLogApi.Models;

public class DutyLog
{

    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [StringLength(10, MinimumLength = 3, ErrorMessage= "Name have to be between 3-10")]
    public string Name { get; set; }

    [Required(ErrorMessage = "StationName is required")]
    [StringLength(10,MinimumLength = 3, ErrorMessage = "At lease 3 chars")]
    public string StationName { get; set; }

    [Required(ErrorMessage = "Shiftstart is required!")] // to validate the range also needed!
    public DateTime ShiftStart { get; set; }

    public DateTime? ShiftEnd { get; set; }

    [StringLength(100,MinimumLength = 3 , ErrorMessage = "The remarks have to be between 3- 100 chars")]
    public string? Remarks { get; set; }

}
