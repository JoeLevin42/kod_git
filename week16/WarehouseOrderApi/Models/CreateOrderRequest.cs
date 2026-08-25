using System.ComponentModel.DataAnnotations;
namespace WarehouseOrderApi.Models;

public class CreateOrderRequest
{
    [Required]
    [StringLength(100)]
    public string CustomerName { get; set; } = string.Empty;
    [Required]
    public int ProductId { get; set; }
    [Range(1, 1000)]
    public int Quantity { get; set; }
}