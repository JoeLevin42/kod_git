using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Models;


[Index(nameof(ISBN), IsUnique  = true)]
public class Book
{
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string Author { get; set; } = string.Empty;

    [Required]
    [StringLength(20)]

    public string ISBN { get; set; } = string.Empty;

    [Range(1800, 2100)]
    public int PublishedYear { get; set; }

    [Range(0, int.MaxValue)]
    public int AvailableCopies { get; set; }
}