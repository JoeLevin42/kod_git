namespace OrderProducer.Models; 
public class Order 
{
    public int OrderId { get; set; } 
    public string CustomerName { get; set; } = string.Empty; 
    public decimal Amount { get; set; } 
    
}