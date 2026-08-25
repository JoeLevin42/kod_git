using DashbordApi.Models;
using DashbordApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DashbordApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UnitsController : ControllerBase
{
    private readonly DashbordRepostiory _repo;
    public UnitsController(DashbordRepostiory repo)
    {
        _repo = repo;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<HostileProccessed>>> GetAllUnitsAsync()
    {
        var allUnits = await _repo.GetAllUnitsAsync();
        return Ok(allUnits);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<HostileProccessed>> GetUnitByIdAsync(int id)
    {
        var theUnit = await _repo.GetUnitByIdAsync(id);
        if (theUnit == null)
        {
            return NotFound();
        }

        return Ok(theUnit);
    }

}