using LibraryTestApi.Models;


namespace LibraryTestApi.Services;

public interface IBookService
{
    // CRUD

    Task<IEnumerable<Book>> GetAllAsync();

    Task<Book?> GetByIdAsync(int id);

    Task<Book?> CreateAsync(Book book);

    Task<bool> UpdateAsync(int id, Book book);

    Task<bool> DeleteAsync(int id);
}