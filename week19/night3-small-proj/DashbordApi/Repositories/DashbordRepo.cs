using DashbordApi.Data;
using DashbordApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DashbordApi.Repo;

public class DashbordRepo
{
    private readonly ApplicationDbContext _context;

    public DashbordRepo(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Analysts>> GetAllAnalysts()
    {
        var all = await _context.Analysts.
            ToListAsync();

        return all;


    }
}