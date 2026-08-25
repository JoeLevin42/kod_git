using System.ComponentModel.DataAnnotations;

namespace ECommerceApi.Models;

public class Category
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    // A category HAS MANY products. This is a navigation property -
    // it doesn't exist as a column in the database. EF Core uses it
    // to let you walk from a Category object to its Products in code.
    public ICollection<Product> Products { get; set; } = new List<Product>();
}