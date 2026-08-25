using LibraryTestApi.Models;
using LibraryTestApi.Models;

namespace LibraryTestApi.Repositories;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetAllAsync();

    Task<Book?> GetByIdAsync(int id);

    Task<Book?> AddAsync(Book book);

    Task<bool> UpdateAsync(int id ,Book book);

    Task<bool> DeleteAsync(int id);
}