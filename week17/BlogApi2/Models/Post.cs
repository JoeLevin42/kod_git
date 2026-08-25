using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace BlogApi2.Models;

public class Post
{
    public int Id { get; set; }

    [Required]
    public int AuthorId { get; set; }

    [Required]
    [StringLength(200)]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string Content { get; set; } = string.Empty;

    public DateTime? PublishedDate { get; set; }

    [Required]
    public bool IsPublished { get; set; }

    // Navigation Property
    [JsonIgnore]
    public Author Author { get; set; } = null!;

    // One Post -> Many Comments

    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
}