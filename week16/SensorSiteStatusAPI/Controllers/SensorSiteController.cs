using Microsoft.AspNetCore.Mvc;
using SensorSiteStatusAPI.Models;

namespace SensorSiteStatusAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class SensorSiteStatusController : ControllerBase
{
    private static readonly List<SensorSite> _reading = new()
{
    new SensorSite
    {
        Id = "1",
        SiteName = "North Factory",
        Zone = "North",
        Status = "Active",
        LastContact = DateTime.Now.AddMinutes(-5)
    },

    new SensorSite
    {
        Id = "2",
        SiteName = "South Warehouse",
        Zone = "South",
        Status = "Silent",
        LastContact = DateTime.Now.AddHours(-3)
    },

    new SensorSite
    {
        Id = "3",
        SiteName = "Main Office",
        Zone = "Center",
        Status = "Active",
        LastContact = DateTime.Now.AddMinutes(-10)
    },

    new SensorSite
    {
        Id = "4",
        SiteName = "Production Line A",
        Zone = "East",
        Status = "Maintenance",
        LastContact = DateTime.Now.AddDays(-1)
    },

    new SensorSite
    {
        Id = "5",
        SiteName = "Security Gate",
        Zone = "West",
        Status = "Active",
        LastContact = DateTime.Now.AddMinutes(-20)
    },

    new SensorSite
    {
        Id = "6",
        SiteName = "Storage Building",
        Zone = "South",
        Status = "Silent",
        LastContact = DateTime.Now.AddHours(-5)
    },

    new SensorSite
    {
        Id = "7",
        SiteName = "Research Center",
        Zone = "North",
        Status = "Maintenance",
        LastContact = DateTime.Now.AddHours(-12)
    },

    new SensorSite
    {
        Id = "8",
        SiteName = "Server Room",
        Zone = "Center",
        Status = "Active",
        LastContact = DateTime.Now.AddSeconds(-30)
    }
};

    [HttpGet]
    public ActionResult<IEnumerable<SensorSite>> GetAllReadings()
    {
        return Ok(_reading);
    }

    [HttpGet("{id}")]
    public ActionResult<SensorSite> GetById(string id)
    {
        var reading = _reading.FirstOrDefault(r => r.Id == id);

        if (reading == null)
        {
            return NotFound();
        }

        return Ok(reading);
    }

    [HttpGet("search")]
    public ActionResult<IEnumerable<SensorSite>> SearchByZone(string zone)
    {
        var results = _reading.Where(r => r.Zone == zone).ToList();
        return Ok(results);
    }

}