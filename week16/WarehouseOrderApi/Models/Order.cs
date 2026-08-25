using System.ComponentModel.DataAnnotations;
namespace WarehouseOrderApi.Models;

public class Order
{
    public int Id { get; set; }
    [Required]
    [StringLength(100)]
    public string CustomerName { get; set; } = string.Empty;
    [Required]
    public int ProductId { get; set; }
    [Range(1, 1000)]
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime OrderDate { get; set; }
    public string Status { get; set; } = "Pending";
}