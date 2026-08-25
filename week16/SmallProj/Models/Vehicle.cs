namespace SamllProj.Models;

using System.ComponentModel.DataAnnotations;

public class Vehicle

{
    [Required(ErrorMessage = "This required")]
    public int Id { get; set; }
    [Required(ErrorMessage = "This required")]
    [StringLength(20, ErrorMessage = "Maximum 20 chars")]
    public string SoldierName { get; set; }

    [Required(ErrorMessage = "This required")]
    [StringLength(10, ErrorMessage = "Maximum 20 chars")]

    public string VechicleNumebr { get; set; }


    [Required(ErrorMessage = "This required")]
    [StringLength(20, ErrorMessage = "Maximum 20 chars")]
    public string Type { get; set; }

}