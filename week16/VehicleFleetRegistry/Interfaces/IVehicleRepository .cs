using Microsoft.AspNetCore.Mvc;
using VehicleFleetRegistry.Models;

namespace VehicleFleetRegistry.Interfaces;

public interface IVehicleRepository
{
    public IEnumerable<Vehicle> GetAll();

    public Vehicle GetById(int id);
    public Vehicle GetByRegistrationNum(string regNum);
    public IEnumerable<Vehicle> GetByStatus(string status);
    public IEnumerable<Vehicle> GetByType(string Type);

    public Vehicle CreateVehicle(Vehicle vechile);
    public Vehicle? Update(int id, Vehicle vechile);

    public bool Delete(int id);
}