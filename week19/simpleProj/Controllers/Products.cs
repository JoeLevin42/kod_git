using Microsoft.AspNetCore.Mvc;
using simpleProj.Repo;
using simpleProj.Models;


namespace simpleProj.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ProductRepository _repository;

    public ProductsController(ProductRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetAllAsync()
    {
        return Ok(await _repository.GetAllAsync());
    }
}