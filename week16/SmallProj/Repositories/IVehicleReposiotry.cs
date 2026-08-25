
using SamllProj.Models;
namespace SamllProj.Reositories;

public interface IVehicleRepository
{
    public Task<IEnumerable<Vehicle>> GetAll();

    public Task<Vehicle> GetById();
    public Task<Vehicle> CreateLocker();
    public Task<Vehicle?> UpdateLocker();
    public bool Delete();

}