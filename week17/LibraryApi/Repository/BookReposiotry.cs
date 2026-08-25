using Microsoft.EntityFrameworkCore;
using LibraryApi.Data;
using LibraryApi.Models;

namespace LibraryApi.Repository;

public class BooksRepository : IBookRepo
{
    private readonly ApplicationDbContext _context;
    public BooksRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        return await _context.Books.ToListAsync();
    }

    public async Task<Book?> GetByIdAsync(int id)
    {
        return await _context.Books.FindAsync(id);
    }

    public async Task<Book?> CreateAsync(Book book)
    {
  
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
        return book;
    }

    public async Task<bool> UpdateAsync(int id, Book updatedBook)
    {
        var exists = await _context.Books.FindAsync(id);
        if (exists == null)
        {
            return false;
        }

        exists.Title = updatedBook.Title;
        exists.Author = updatedBook.Author;
        exists.ISBN = updatedBook.ISBN;
        exists.PublishedYear = updatedBook.PublishedYear;
        exists.AvailableCopies = updatedBook.AvailableCopies;

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existsBook = await _context.Books.FindAsync(id);
        if (existsBook == null)
        {
            return false;
        }

        _context.Books.Remove(existsBook);
        return true;
    }



}
