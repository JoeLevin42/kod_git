
using SamllProj.Models;
namespace SamllProj.Reositories;

public interface ILockerRepository
{
    public Task<IEnumerable<Locker>> GetAll();

    public Task<Locker> GetById();
    public Task<Locker> CreateLocker();
    public Task<Locker?> UpdateLocker();
    public bool Delete();

}