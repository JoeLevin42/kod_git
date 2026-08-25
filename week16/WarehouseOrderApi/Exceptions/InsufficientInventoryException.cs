namespace WarehouseOrderApi.Exceptions;

public class InsufficientInventoryException : Exception
{
    public int ProductId { get; }
    public int RequestedQuantity { get; }
    public int AvailableQuantity { get; }

    public InsufficientInventoryException(
        int productId,
        int requestedQuantity,
        int availableQuantity)
        : base($"Insufficient inventory for product {productId}. Requested: {requestedQuantity}, Available: {availableQuantity}")
    {
        ProductId = productId;
        RequestedQuantity = requestedQuantity;
        AvailableQuantity = availableQuantity;
    }
}