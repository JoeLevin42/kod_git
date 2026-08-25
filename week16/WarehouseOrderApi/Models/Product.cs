using System.ComponentModel.DataAnnotations;
namespace WarehouseOrderApi.Models;

public class Product
{
    public int Id { get; set; }
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;
    [Required]
    [StringLength(50)]
    public string SKU { get; set; } = string.Empty;
    [Range(0, int.MaxValue)]
    public int QuantityInStock { get; set; }
    [Range(0.01, double.MaxValue)]
    public decimal UnitPrice { get; set; }
}