using simpleProj.Models;
using MongoDB.Driver;


namespace simpleProj.Repo;

public class ProductRepository
{
    private readonly IMongoCollection<Product> _products;
    public ProductRepository(IMongoCollection<Product> products)
    {
        _products = products;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _products.Find(_ => true).ToListAsync();
    }
}
