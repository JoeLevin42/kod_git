using DashbordApi.Data;
using DashbordApi.Models;
using Microsoft.EntityFrameworkCore;
namespace DashbordApi.Repositories;

public class DashbordRepostiory
{
    private readonly ApplicationDbContext _db;

    public DashbordRepostiory(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<HostileProccessed>> GetAllUnitsAsync()
    {
        return await _db.HostileUnits.ToListAsync();
    }

    public async Task<HostileProccessed?> GetUnitByIdAsync(int id)
    {
        var theUnit = await _db.HostileUnits
            .FirstOrDefaultAsync(e => e.unit_id == id);
        if (theUnit == null)
        {
            return null;
        }
        return theUnit;
    }


}
