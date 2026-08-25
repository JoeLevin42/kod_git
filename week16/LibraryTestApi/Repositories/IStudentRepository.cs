using LibraryTestApi.Models;
using LibraryTestApi.Models;

namespace LibraryTestApi.Repositories;

public interface IStudentRepository
{
    Task<IEnumerable<Student>> GetAllAsync();

    Task<Student?> GetByIdAsync(int id);

    Task<Student?> AddAsync(Student student);

    Task<bool> UpdateAsync(int id ,Student student);

    Task<bool> DeleteAsync(int id);
}