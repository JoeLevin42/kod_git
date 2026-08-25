using WarehouseOrderApi.Models;
namespace WarehouseOrderApi.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly List<Order> _orders = new();
    private int _nextId = 1;
    public async Task<IEnumerable<Order>> GetAllAsync()
    {

        await Task.Delay(10);
        return _orders;
    }
    public async Task<Order?> GetByIdAsync(int id)
    {
        await Task.Delay(10);
        return _orders.FirstOrDefault(o => o.Id == id);
    }
    public async Task<Order> CreateAsync(Order order)
    {
        await Task.Delay(10);
        order.Id = _nextId++;
        order.OrderDate = DateTime.UtcNow;
        _orders.Add(order);
        return order;
    }
}