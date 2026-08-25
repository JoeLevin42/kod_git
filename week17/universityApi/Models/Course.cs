using System.ComponentModel.DataAnnotations;
namespace UniversityApi.Models;

public class Course
{
    public int Id { get; set; }
    [Required]
    [StringLength(20)]
    public string CourseCode { get; set; } = string.Empty;
    [Required]
    [StringLength(200)]
    public string CourseName { get; set; } = string.Empty;
    [Range(1, 10)]
    public int Credits { get; set; }
}