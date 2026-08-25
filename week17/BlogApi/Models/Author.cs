using BlogApi.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace BlogApi.Models;

public class Author
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string FullName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public DateTime JoinedDate { get; set; }

    // One Author -> Many Posts
   
    public ICollection<Post> Posts { get; set; } = new List<Post>();
}