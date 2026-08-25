
using System.ComponentModel.DataAnnotations;

namespace LibraryTestApi.Models;




public class Book
{
    public int Id { get; set; }


    [Required]
    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;


    [Required]
    [MaxLength(100)]
    public string Author { get; set; } = string.Empty;


    [RegularExpression("^(Fiction|NonFiction|Science)$")]
    public string Genre { get; set; } = string.Empty;


    [Range(1000, 2030)]
    public int Year { get; set; }


    public bool IsAvailable { get; set; }
}