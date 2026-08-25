using Microsoft.AspNetCore.Mvc;
using SatellitesTelemetryDataApi.Repositories;
using SatellitesTelemetryDataApi.Models;

namespace SatellitesTelemetryDataApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SatellitesController : ControllerBase
{
    private readonly ISatelliteRepository _satelliteRepo;
    public SatellitesController(ISatelliteRepository _satelliteRepo)
    {
        _satelliteRepo = _satelliteRepo;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Satellite>>> GetAll()
    {
        var allSats = await _satelliteRepo.GetAllAsync();

        return Ok(allSats);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Satellite>> GetById(int id)
    {
        var sat = await _satelliteRepo.GetByIdAsync(id);
        if (sat == null)
        {
            return NotFound();
        }

        return Ok(sat);

    }

    [HttpPost]
    public async Task<ActionResult<Satellite>> Create(Satellite sat)

    {
        var createdSat = await _satelliteRepo.CreateAsync(sat);

        return CreatedAtAction(nameof(GetById), new { id = sat.Id }, sat);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Satellite updatedSat)
    {
        var existsSat = await _satelliteRepo.GetByIdAsync(id);

        if (existsSat == null)
        {
            return NotFound();
        }

        await _satelliteRepo.UpdateAsync(id, updatedSat);

        return NoContent();


    }

}