using System.ComponentModel.DataAnnotations;
namespace UniversityApi.Models;

public class Student
{
    public int Id { get; set; }
    [Required]
    [StringLength(100)]
    public string FullName { get; set; } = string.Empty;
    [Required]
    [EmailAddress]
public string Email { get; set; } = string.Empty;
    [Required]
    [StringLength(20)]
    public string StudentNumber { get; set; } = string.Empty;
    public DateTime EnrolledAt { get; set; } = DateTime.UtcNow;
}