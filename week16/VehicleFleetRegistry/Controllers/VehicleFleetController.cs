using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using VehicleFleetRegistry.Interfaces;
using VehicleFleetRegistry.Models;

namespace VehicleFleetRegistry.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehiclesController : ControllerBase
{
    private readonly IVehicleRepository _repostiory;
    public VehiclesController(IVehicleRepository repository)
    {
        _repostiory = repository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Vehicle>> GetAll()
    {
        return Ok(_repostiory.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<Vehicle> GetById(int id)
    {
        var vehicle = _repostiory.GetById(id);
        if (vehicle == null)
        {
            return NotFound();
        }
        return Ok(vehicle);
    }

    [HttpGet("registration/{regNum}")]
    public ActionResult<Vehicle> _repostioryGetByRegistrationNum(string regNum)
    {
        var vehicle = _repostiory.GetByRegistrationNum(regNum);
        if (vehicle == null)
        {
            return BadRequest();
        }

        return Ok(vehicle);
    }

    [HttpGet("status")]
    public ActionResult<IEnumerable<Vehicle>> GetByStatus([FromQuery]string status)
    {
        var result = _repostiory.GetByStatus(status);

        return Ok(result);
    }

    [HttpGet("type")]
    public ActionResult<IEnumerable<Vehicle>> GetByType([FromQuery] string type)
    {
        var result = _repostiory.GetByType(type);

        return Ok(result);
    }

    [HttpPost]
    public ActionResult<Vehicle> CreateVehicle([FromBody] Vehicle vehicle)
    {
        var resultVehicle = _repostiory.CreateVehicle(vehicle);

        return CreatedAtAction(nameof(GetById), new { id = resultVehicle.Id }, resultVehicle);

    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Vehicle updatedVehille)
    {
        var result = _repostiory.Update(id, updatedVehille);

        if (result == null)
        {
            return NotFound();
        }
        return NoContent();
    }


    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var isDeleted = _repostiory.Delete(id);

        if (!isDeleted)
        {
            return NotFound();
        }

        return NoContent();

    }

}


