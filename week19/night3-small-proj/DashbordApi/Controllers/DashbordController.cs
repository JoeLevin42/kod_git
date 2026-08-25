using Microsoft.AspNetCore.Mvc;
using DashbordApi.Models;
using DashbordApi.Repo;


namespace DashbordApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DashbordController : ControllerBase
{
    private readonly DashbordRepo _repo;

    public DashbordController(DashbordRepo repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Analysts>>> GetAlAnalystsAsync()
    {
        var res = await _repo.GetAllAnalysts();
        return Ok(res);
           
    }
}