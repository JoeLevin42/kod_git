using System.ComponentModel.DataAnnotations;

namespace ECommerceApi.Models;

public class Product
{
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public decimal Price { get; set; }

    public int StockQuantity { get; set; }

    // The foreign key - a plain int column in the Products table.
    [Required]
    public int CategoryId { get; set; }

    // The navigation property - lets you write product.Category.Name
    // instead of a manual lookup. Note the null-forgiving operator (= null!):
    // we're telling the compiler "trust me, this will be set" - either by
    // EF Core when it loads the row, or by us when we assign a Category
    // before saving. It's required (CategoryId is [Required]), so it
    // should never actually be null at runtime.
    public Category Category { get; set; } = null!;

    // One product has many reviews - same pattern as Category.Products above.
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
}