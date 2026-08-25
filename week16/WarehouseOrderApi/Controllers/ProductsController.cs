using Microsoft.AspNetCore.Mvc;
using WarehouseOrderApi.Models;
using WarehouseOrderApi.Repositories;
namespace WarehouseOrderApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _repository;
    public ProductsController(IProductRepository repository)
    {
        _repository = repository;
    }


    // GET: api/products
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetAll()
    {
        var products = await _repository.GetAllAsync();
        return Ok(products);
    }

    // GET: api/products/3
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetById(int id)
    {
        var product = await _repository.GetByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }
    // GET: api/products/sku/NVG-001
    [HttpGet("sku/{sku}")]
    public async Task<ActionResult<Product>> GetBySKU(string sku)
    {
        var product = await _repository.GetBySKUAsync(sku);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }
    // POST: api/products
    [HttpPost]
    public async Task<ActionResult<Product>> Create(Product product)
    {
        var created = await _repository.CreateAsync(product);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }
    // PUT: api/products/3
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Product product)
    {
        var updated = await _repository.UpdateAsync(id, product);
        if (updated == null)
        {
            return NotFound();
        }
        return NoContent();
    }
    // DELETE: api/products/3
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _repository.DeleteAsync(id);
        if (!success)
        {
            return NotFound();
        }
        return NoContent();
    }
}