using Microsoft.AspNetCore.Mvc;
using DutyLogApi.Models;

[ApiController]
[Route("api/[controller")]
public class DutyLogController : ControllerBase
{
    private static readonly List<DutyLog> _dutyLogs = new()
{
    new DutyLog
    {
        Id = 1,
        Name = "John",
        StationName = "Alpha",
        ShiftStart = DateTime.UtcNow.AddHours(-10),
        ShiftEnd = DateTime.UtcNow.AddHours(-2),
        Remarks = "Normal shift completed"
    },

    new DutyLog
    {
        Id = 2,
        Name = "Anna",
        StationName = "Bravo",
        ShiftStart = DateTime.UtcNow.AddHours(-8),
        ShiftEnd = DateTime.UtcNow,
        Remarks = "Late arrival"
    },

    new DutyLog
    {
        Id = 3,
        Name = "Mike",
        StationName = "Delta",
        ShiftStart = DateTime.UtcNow.AddHours(-12),
        ShiftEnd = DateTime.UtcNow.AddHours(-4),
        Remarks = null
    },

    new DutyLog
    {
        Id = 4,
        Name = "Sara",
        StationName = "Echo",
        ShiftStart = DateTime.UtcNow.AddHours(-6),
        Remarks = "Working overtime"
    },

    new DutyLog
    {
        Id = 5,
        Name = "David",
        StationName = "Gamma",
        ShiftStart = DateTime.UtcNow.AddHours(-9),
        ShiftEnd = DateTime.UtcNow.AddHours(-1),
        Remarks = "Routine inspection"
    },

    new DutyLog
    {
        Id = 6,
        Name = "Emma",
        StationName = "North",
        ShiftStart = DateTime.UtcNow.AddHours(-7),
        Remarks = null
    },

    new DutyLog
    {
        Id = 7,
        Name = "Alex",
        StationName = "South",
        ShiftStart = DateTime.UtcNow.AddHours(-5),
        ShiftEnd = DateTime.UtcNow.AddHours(-2),
        Remarks = "Equipment checked"
    },

    new DutyLog
    {
        Id = 8,
        Name = "Tom",
        StationName = "West",
        ShiftStart = DateTime.UtcNow.AddHours(-11),
        ShiftEnd = DateTime.UtcNow.AddHours(-3),
        Remarks = "Completed patrol"
    },

    new DutyLog
    {
        Id = 9,
        Name = "Liam",
        StationName = "East",
        ShiftStart = DateTime.UtcNow.AddHours(-4),
        Remarks = "Short duty period"
    },

    new DutyLog
    {
        Id = 10,
        Name = "Maya",
        StationName = "Main",
        ShiftStart = DateTime.UtcNow.AddHours(-10),
        ShiftEnd = DateTime.UtcNow.AddHours(-5),
        Remarks = null
    },

    new DutyLog
    {
        Id = 11,
        Name = "Noah",
        StationName = "Gate",
        ShiftStart = DateTime.UtcNow.AddHours(-3),
        Remarks = "Gate monitoring"
    },

    new DutyLog
    {
        Id = 12,
        Name = "Ella",
        StationName = "Room",
        ShiftStart = DateTime.UtcNow.AddHours(-14),
        ShiftEnd = DateTime.UtcNow.AddHours(-6),
        Remarks = "Regular check"
    },

    new DutyLog
    {
        Id = 13,
        Name = "Adam",
        StationName = "Base",
        ShiftStart = DateTime.UtcNow.AddHours(-13),
        Remarks = null
    },

    new DutyLog
    {
        Id = 14,
        Name = "Nina",
        StationName = "Tower",
        ShiftStart = DateTime.UtcNow.AddHours(-2),
        Remarks = "Security duty"
    },

    new DutyLog
    {
        Id = 15,
        Name = "Owen",
        StationName = "Zone",
        ShiftStart = DateTime.UtcNow.AddHours(-15),
        ShiftEnd = DateTime.UtcNow.AddHours(-7),
        Remarks = "Completed tasks"
    },

    new DutyLog
    {
        Id = 16,
        Name = "Chris",
        StationName = "Unit",
        ShiftStart = DateTime.UtcNow.AddHours(-16),
        Remarks = null
    },

    new DutyLog
    {
        Id = 17,
        Name = "Jack",
        StationName = "Dock",
        ShiftStart = DateTime.UtcNow.AddHours(-1),
        Remarks = "New assignment"
    },

    new DutyLog
    {
        Id = 18,
        Name = "Rose",
        StationName = "Park",
        ShiftStart = DateTime.UtcNow.AddHours(-20),
        ShiftEnd = DateTime.UtcNow.AddHours(-12),
        Remarks = "Morning shift"
    },

    new DutyLog
    {
        Id = 19,
        Name = "Mark",
        StationName = "Lab",
        ShiftStart = DateTime.UtcNow.AddHours(-18),
        Remarks = "Testing equipment"
    },

    new DutyLog
    {
        Id = 20,
        Name = "Kate",
        StationName = "Ops",
        ShiftStart = DateTime.UtcNow.AddHours(-21),
        ShiftEnd = DateTime.UtcNow.AddHours(-15),
        Remarks = "Operations completed"
    }
};

    private static int _nextId = 21;


    [HttpGet]
    public ActionResult<IEnumerable<DutyLog>> GetAllDuties()
    {
        return Ok(_dutyLogs);
    }

    [HttpGet("{id}")]
    public ActionResult <DutyLog> GetById( int id)
    {
        var log = _dutyLogs.FirstOrDefault(l => l.Id == id);
        if (id == null)
        {
            return BadRequest("Id not found");
        }

        return Ok(log);
    }


    [HttpPost]
    public ActionResult<DutyLog> CreateNewLog(DutyLog dutyLog)
    {
        dutyLog.Id = _nextId++;
        _dutyLogs.Add(dutyLog);

        return CreatedAtAction(nameof(GetById), new { id = dutyLog.Id }, dutyLog);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateFullLog (int id ,DutyLog updatedLog)
    {
        var existsLog = _dutyLogs.FirstOrDefault(l => l.Id == id);
        if(existsLog == null)
        {
            return BadRequest();
        }
        existsLog.Name = updatedLog.Name;
        existsLog.StationName = updatedLog.StationName;
        existsLog.ShiftStart = updatedLog.ShiftStart;
        existsLog.ShiftEnd = updatedLog.ShiftEnd;
        existsLog.Remarks = updatedLog.Remarks;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteLog(int id)
    {
        var log = _dutyLogs.FirstOrDefault(l => l.Id == id);
        if (log == null)
        {
            return BadRequest();
        }

        _dutyLogs.Remove(log);

        return NoContent();
    }

}