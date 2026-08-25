using VehicleFleetRegistry.Interfaces;
using VehicleFleetRegistry.Models;
using VehicleFleetRegistry.Interfaces;

namespace VehicleFleetRegistry.Repositories;

public class VehicleRepository : IVehicleRepository
{
    private int _nextId = 9;
    private  readonly List<Vehicle> _vehicles = new()
{
    new Vehicle
    {
        Id = 1,
        RegistrationNum = "ABC123",
        VecihleType = "Sedan",
        Status = "Available",
        AssigendDriver = "John Smith",
        Location = "New York",
        Mileage = 15230
    },

    new Vehicle
    {
        Id = 2,
        RegistrationNum = "XYZ9876",
        VecihleType = "Truck",
        Status = "In-Use",
        AssigendDriver = "Emily Johnson",
        Location = "Chicago",
        Mileage = 89540
    },

    new Vehicle
    {
        Id = 3,
        RegistrationNum = "BUS2024",
        VecihleType = "Bus",
        Status = "Maintenance",
        AssigendDriver = null,
        Location = "Maintenance Garage",
        Mileage = 230100
    },

    new Vehicle
    {
        Id = 4,
        RegistrationNum = "VAN555",
        VecihleType = "Van",
        Status = "Available",
        AssigendDriver = "Michael Brown",
        Location = "Los Angeles",
        Mileage = 45670
    },

    new Vehicle
    {
        Id = 5,
        RegistrationNum = "CAR777",
        VecihleType = "SUV",
        Status = "In-Use",
        AssigendDriver = "Sarah Davis",
        Location = "Houston",
        Mileage = 78320
    },

    new Vehicle
    {
        Id = 6,
        RegistrationNum = "TRK909",
        VecihleType = "Pickup Truck",
        Status = "Decommissioned",
        AssigendDriver = null,
        Location = "Storage Yard",
        Mileage = 489900
    },

    new Vehicle
    {
        Id = 7,
        RegistrationNum = "MIN888",
        VecihleType = "Minivan",
        Status = "Available",
        AssigendDriver = "David Wilson",
        Location = "Phoenix",
        Mileage = 31500
    },

    new Vehicle
    {
        Id = 8,
        RegistrationNum = "ELC101",
        VecihleType = "Electric Car",
        Status = "Maintenance",
        AssigendDriver = "Jessica Taylor",
        Location = "Service Center",
        Mileage = 12450
    }
};




    public IEnumerable<Vehicle> GetAll()
    {
        return _vehicles;
    }

    public Vehicle? GetById(int id)
    {
        var vehicle = _vehicles.FirstOrDefault(v => v.Id == id);

        return vehicle;
    }

    public Vehicle? GetByRegistrationNum(string regNumber)
    {
        var vechile = _vehicles.FirstOrDefault(v => v.RegistrationNum == regNumber);

        return vechile;
    }

    public IEnumerable<Vehicle> GetByStatus(string status)
    {
        var result = _vehicles.Where(v => v.Status == status);

        return result;
    }

    public IEnumerable<Vehicle> GetByType(string type)
    {
        var result = _vehicles.Where(v => v.VecihleType == type);
        return result;
    }

    public Vehicle CreateVehicle(Vehicle vehicle)
    {
        vehicle.Id = _nextId++;
        _vehicles.Add(vehicle);

        return vehicle;
    }

    public Vehicle? Update(int id , Vehicle updatedVehille)
    {
        var existsVehicle = GetById(id);

        if (existsVehicle == null)
        {
            return null;
        }

        existsVehicle.RegistrationNum = updatedVehille.RegistrationNum;
        existsVehicle.VecihleType = updatedVehille.VecihleType;
        existsVehicle.Status = updatedVehille.Status;
        existsVehicle.AssigendDriver = updatedVehille.AssigendDriver;
        existsVehicle.Location = updatedVehille.Location;
        existsVehicle.Mileage = updatedVehille.Mileage;

        return existsVehicle;

    }

    public bool Delete(int id)
    {
        var vehicle = GetById(id);
        if (vehicle == null)
        {
            return false;
        }

        _vehicles.Remove(vehicle);
        return true;
    }
}