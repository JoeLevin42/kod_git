using DashboardApi.Data;
using DashboardApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace DashboardApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ParkingController : ControllerBase
{
    private readonly SmartCityDbContext _context;

    public ParkingController(SmartCityDbContext context)
    {
        _context = context;
    }

    [HttpGet("latest")]
    public async Task<ActionResult<IEnumerable<ParkingEvent>>> GetLatest(int count = 10)
    {
        var latest = await _context.ParkingEvents
            .OrderByDescending(e => e.Timestamp)
            .Take(count)
            .ToListAsync();
        

        return Ok(latest);
            
    }


}