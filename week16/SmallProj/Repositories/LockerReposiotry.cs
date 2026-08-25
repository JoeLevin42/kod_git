
using SamllProj.Models;
using SamllProj.Reositories; 
namespace SamllProj.Reositories;

public class LockerRepository : ILockerRepository

{
    private  int _nextId = 6;
    private  readonly List<Locker> _lockers = new()
{
    new Locker
    {
        Id = 1,
        SoldierName = "David",
        LockerNumber = 101,
        Location = "North",
        IsOccupied = true
    },
    new Locker
    {
        Id = 2,
        SoldierName = "Daniel",
        LockerNumber = 102,
        Location = "South",
        IsOccupied = true
    },
    new Locker
    {
        Id = 3,
        SoldierName = "",
        LockerNumber = 103,
        Location = "North",
        IsOccupied = false
    },
    new Locker
    {
        Id = 4,
        SoldierName = "",
        LockerNumber = 104,
        Location = "East",
        IsOccupied = false
    },
    new Locker
    {
        Id = 5,
        SoldierName = "Yossi",
        LockerNumber = 105,
        Location = "West",
        IsOccupied = true
    }
};

    public Task<IEnumerable<Locker> GetAll()
    {
        return _lockers;
    }
}
