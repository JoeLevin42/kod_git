namespace SamllProj.Models;

using System.ComponentModel.DataAnnotations;


public class Locker
{
    public int Id { get; set; }

    [Required(ErrorMessage = "This is required")]
    [StringLength(20 ,ErrorMessage = "This is can be max 20 chars")]
    public string SoldierName { get; set; }
    [Required(ErrorMessage = "This is required")]
    [Range(1,500, ErrorMessage = "This can be in range of 1 - 500")]
    public  int LockerNumber { get; set; }

    [Required(ErrorMessage = "This is required")]
    [StringLength(15, ErrorMessage = "This is can be max 15 chars")]
    public string Location { get; set; }

    public bool IsOccupied { get; set; }
}