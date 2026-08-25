using LibraryTestApi.Models;
using LibraryTestApi.Services;
using LibraryTestApi.Repositories;

namespace LibraryTestApi.Services;

class BookService : IBookService
{
    private IBookRepository _bookRepository;
    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        return await _bookRepository.GetAllAsync();
    }

    public async Task<Book?> GetByIdAsync(int id)
    {
        var book = await _bookRepository.GetByIdAsync(id);
        if (book == null)
        {
            return null;
        }

        return book;
    }

    public async Task<Book?> CreateAsync(Book book)

    {   
        var createdBook = await _bookRepository.AddAsync(book);

        return createdBook;
        
     }

    public async Task<bool> UpdateAsync(int id, Book book)
    {
        var isUpdated = await _bookRepository.UpdateAsync(id, book);

        return isUpdated;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var isDeleted = await _bookRepository.DeleteAsync(id);

        return isDeleted;
    }



}