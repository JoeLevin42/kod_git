using System.ComponentModel.DataAnnotations;
using BlogApi.Models;
using System.Text.Json.Serialization;


namespace BlogApi.Models;

public class Comment
{
    public int Id { get; set; }

    [Required]
    public int PostId { get; set; }

    [Required]
    [StringLength(100)]
    public string CommenterName { get; set; } = string.Empty;

    [Required]
    public string Text { get; set; } = string.Empty;

    [Required]
    public DateTime CreatedAt { get; set; }

    // Navigation Property
    [JsonIgnore]
    public Post Post { get; set; } = null!;
}