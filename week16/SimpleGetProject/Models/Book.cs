
namespace SimpleBookAPI.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Category { get; set; }
    public int Year { get; set; }
    public int Price { get; set; }
    public bool IsAvailable { get; set; }
}