using Microsoft.AspNetCore.Mvc;
using SatellitesTelemetryDataApi.Services;
using SatellitesTelemetryDataApi.Models;

namespace SatellitesTelemetryDataApi.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class TelemetryController : ControllerBase
{
    private readonly ITelemetryService _telmetryService;

    public TelemetryController(ITelemetryService telmetryService)
    {
        _telmetryService = telmetryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TelemetryReport>>> GetAll()
    {
        var allTel = await _telmetryService.GetAllReportsAsync();

        return Ok(allTel);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TelemetryReport>> GetById(int id)
    {
        var theTel = await _telmetryService.GetReportByIdAsync(id);

        return theTel;
    }

    [HttpGet("satellite")]
    public async Task<ActionResult<IEnumerable<TelemetryReport>>> GetAllFromSatellite([FromQuery]int satelliteId)
    {
        var selected = await _telmetryService.GetReportsBySatelliteIdAsync(satelliteId);

        return Ok(selected);
    }

    [HttpPost]
    public async Task<ActionResult<TelemetryReport>> SubmitTelemetry(TelemetryReportRequest request)
    {
        var report = await _telmetryService.SubmitTelemetryAsync(request);

        if(report == null)
        {
            return BadRequest();
        }

        return CreatedAtAction(nameof(GetById), new { id = report.Id }, report);


    }




}