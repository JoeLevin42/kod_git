
using System.ComponentModel.DataAnnotations;



namespace LibraryTestApi.Models;

public class Student
{
    public int Id { get; set; }


    [Required]
    public string Name { get; set; } = string.Empty;


    [RegularExpression("^(10|11|12)$")]
    public string Grade { get; set; } = string.Empty;


    public int BookId { get; set; }


    public DateTime BorrowDate { get; set; }
}