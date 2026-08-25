using WarehouseOrderApi.Models;
namespace WarehouseOrderApi.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly List<Product> _products;
    private int _nextId;
    public ProductRepository()
    {
        _nextId = 4;
        _products = new List<Product>
        {
        new Product
        {
        Id = 1,
        Name = "Night Vision Goggles",
        SKU = "NVG-001",
        QuantityInStock = 50,
        UnitPrice = 1200.00m
        },
        new Product
        {
        Id = 2,
        Name = "Tactical Radio",
        SKU = "RAD-002",
        QuantityInStock = 30,
        UnitPrice = 450.00m
        },

        new Product
        {
        Id = 3,
        Name = "Body Armor Vest",
        SKU = "ARM-003",
        QuantityInStock = 20,
        UnitPrice = 800.00m
        }
        };
    }
    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        // Simulate async I/O operation (e.g., database query)
        await Task.Delay(10);
        return _products;
    }
    public async Task<Product?> GetByIdAsync(int id)
    {
        await Task.Delay(10);
        return _products.FirstOrDefault(p => p.Id == id);
    }
    public async Task<Product?> GetBySKUAsync(string sku)

    {
        await Task.Delay(10);
        return _products.FirstOrDefault(p =>
        p.SKU.Equals(sku, StringComparison.OrdinalIgnoreCase));
    }
    public async Task<Product> CreateAsync(Product product)
    {
        await Task.Delay(10);
        product.Id = _nextId++;
        _products.Add(product);
        return product;
    }
    public async Task<Product?> UpdateAsync(int id, Product updatedProduct)
    {
        await Task.Delay(10);
        var existing = _products.FirstOrDefault(p => p.Id == id);
        if (existing == null)
        {
            return null;
        }
        existing.Name = updatedProduct.Name;

        existing.SKU = updatedProduct.SKU;
        existing.QuantityInStock = updatedProduct.QuantityInStock;
        existing.UnitPrice = updatedProduct.UnitPrice;
        return existing;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        await Task.Delay(10);
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return false;
        }
        _products.Remove(product);
        return true;
    }
    public async Task<bool> UpdateStockAsync(int productId, int quantityChange)
    {
        await Task.Delay(10);
        var product = _products.FirstOrDefault(p => p.Id == productId);
        if (product == null)
        {

            return false;
        }
        product.QuantityInStock += quantityChange;
        return true;
    }
}