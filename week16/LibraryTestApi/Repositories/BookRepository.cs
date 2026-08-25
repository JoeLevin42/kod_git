using LibraryTestApi.Models;

namespace LibraryTestApi.Repositories;

public class BookRepository : IBookRepository
{
    private readonly List<Book> _books;
    private int _nextId;

    public BookRepository()
    {
        _books = new List<Book>
        {
            new Book
            {
                Id = 1,
                Title = "Harry Potter and the Sorcerer's Stone",
                Author = "J.K. Rowling",
                Genre = "Fiction",
                Year = 1997,
                IsAvailable = true
            },
            new Book
            {
                Id = 2,
                Title = "The Hobbit",
                Author = "J.R.R. Tolkien",
                Genre = "Fiction",
                Year = 1937,
                IsAvailable = false
            },
            new Book
            {
                Id = 3,
                Title = "A Brief History of Time",
                Author = "Stephen Hawking",
                Genre = "Science",
                Year = 1988,
                IsAvailable = true
            },
            new Book
            {
                Id = 4,
                Title = "Sapiens",
                Author = "Yuval Noah Harari",
                Genre = "NonFiction",
                Year = 2011,
                IsAvailable = true
            },
            new Book
            {
                Id = 5,
                Title = "1984",
                Author = "George Orwell",
                Genre = "Fiction",
                Year = 1949,
                IsAvailable = false
            },
            new Book
            {
                Id = 6,
                Title = "The Selfish Gene",
                Author = "Richard Dawkins",
                Genre = "Science",
                Year = 1976,
                IsAvailable = true
            },
            new Book
            {
                Id = 7,
                Title = "Educated",
                Author = "Tara Westover",
                Genre = "NonFiction",
                Year = 2018,
                IsAvailable = true
            },
            new Book
            {
                Id = 8,
                Title = "The Great Gatsby",
                Author = "F. Scott Fitzgerald",
                Genre = "Fiction",
                Year = 1925,
                IsAvailable = true
            },
            new Book
            {
                Id = 9,
                Title = "Cosmos",
                Author = "Carl Sagan",
                Genre = "Science",
                Year = 1980,
                IsAvailable = false
            },
            new Book
            {
                Id = 10,
                Title = "Thinking, Fast and Slow",
                Author = "Daniel Kahneman",
                Genre = "NonFiction",
                Year = 2011,
                IsAvailable = true
            }
        };

        _nextId = _books.Max(b => b.Id) + 1;
    }

    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        await Task.Delay(10);
        return _books;
    }

    public async Task<Book?> GetByIdAsync(int id)
    {
        await Task.Delay(10);
        var book =  _books.FirstOrDefault(b => b.Id == id);

        return book;
    }

    public async Task<Book> AddAsync(Book book)
    {
        await Task.Delay(10);
        book.Id = _nextId++;
        _books.Add(book);

        return book;
    }

    public async Task<bool> UpdateAsync(int id, Book updateBook)
    {
        await Task.Delay(10);

        var existsBook = _books.FirstOrDefault(b => b.Id == id);
        if (existsBook == null)
        {
            return false;
        }

        existsBook.Title = updateBook.Title;
        existsBook.Author = updateBook.Author;
        existsBook.Year = updateBook.Year;
        existsBook.Genre = updateBook.Genre;
        existsBook.IsAvailable = updateBook.IsAvailable;

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        await Task.Delay(10);

        var existsBook = _books.FirstOrDefault(b => b.Id == id);
        if (existsBook == null)
        {
            return false;
        }

        _books.Remove(existsBook);
        return true;
    }







}