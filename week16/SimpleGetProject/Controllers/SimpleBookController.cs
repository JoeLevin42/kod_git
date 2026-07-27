using Microsoft.AspNetCore.Mvc;
using SimpleBookAPI.Models;

namespace SimpleBookAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SimpleBookController : ControllerBase
{
    private static readonly List<Book> _books = new()
{
    new Book
    {
        Id = 1,
        Title = "Clean Code",
        Author = "Robert Martin",
        Category = "Programming",
        Year = 2008,
        Price = 50,
        IsAvailable = true
    },

    new Book
    {
        Id = 2,
        Title = "The Pragmatic Programmer",
        Author = "Andrew Hunt",
        Category = "Programming",
        Year = 1999,
        Price = 70,
        IsAvailable = true
    },

    new Book
    {
        Id = 3,
        Title = "Design Patterns",
        Author = "Gang of Four",
        Category = "Programming",
        Year = 1994,
        Price = 80,
        IsAvailable = false
    },

    new Book
    {
        Id = 4,
        Title = "C# in Depth",
        Author = "Jon Skeet",
        Category = "Programming",
        Year = 2019,
        Price = 65,
        IsAvailable = true
    },

    new Book
    {
        Id = 5,
        Title = "Introduction to Algorithms",
        Author = "Thomas Cormen",
        Category = "Computer Science",
        Year = 2009,
        Price = 120,
        IsAvailable = false
    },

    new Book
    {
        Id = 6,
        Title = "Database System Concepts",
        Author = "Abraham Silberschatz",
        Category = "Database",
        Year = 2010,
        Price = 90,
        IsAvailable = true
    },

    new Book
    {
        Id = 7,
        Title = "Learning SQL",
        Author = "Alan Beaulieu",
        Category = "Database",
        Year = 2020,
        Price = 55,
        IsAvailable = true
    },

    new Book
    {
        Id = 8,
        Title = "Harry Potter",
        Author = "J.K Rowling",
        Category = "Fantasy",
        Year = 1997,
        Price = 40,
        IsAvailable = true
    },

    new Book
    {
        Id = 9,
        Title = "The Hobbit",
        Author = "J.R.R Tolkien",
        Category = "Fantasy",
        Year = 1937,
        Price = 35,
        IsAvailable = false
    },

    new Book
    {
        Id = 10,
        Title = "The Lord of the Rings",
        Author = "J.R.R Tolkien",
        Category = "Fantasy",
        Year = 1954,
        Price = 75,
        IsAvailable = true
    },

    new Book
    {
        Id = 11,
        Title = "Atomic Habits",
        Author = "James Clear",
        Category = "Self Development",
        Year = 2018,
        Price = 45,
        IsAvailable = true
    },

    new Book
    {
        Id = 12,
        Title = "Rich Dad Poor Dad",
        Author = "Robert Kiyosaki",
        Category = "Finance",
        Year = 1997,
        Price = 30,
        IsAvailable = false
    },

    new Book
    {
        Id = 13,
        Title = "The Intelligent Investor",
        Author = "Benjamin Graham",
        Category = "Finance",
        Year = 1949,
        Price = 60,
        IsAvailable = true
    },

    new Book
    {
        Id = 14,
        Title = "Clean Architecture",
        Author = "Robert Martin",
        Category = "Programming",
        Year = 2017,
        Price = 85,
        IsAvailable = true
    },

    new Book
    {
        Id = 15,
        Title = "Artificial Intelligence",
        Author = "Stuart Russell",
        Category = "Computer Science",
        Year = 2021,
        Price = 110,
        IsAvailable = false
    },

    new Book
    {
        Id = 16,
        Title = "The Psychology of Money",
        Author = "Morgan Housel",
        Category = "Finance",
        Year = 2020,
        Price = 42,
        IsAvailable = true
    },

    new Book
    {
        Id = 17,
        Title = "Dune",
        Author = "Frank Herbert",
        Category = "Science Fiction",
        Year = 1965,
        Price = 55,
        IsAvailable = true
    },

    new Book
    {
        Id = 18,
        Title = "1984",
        Author = "George Orwell",
        Category = "Science Fiction",
        Year = 1949,
        Price = 25,
        IsAvailable = false
    },

    new Book
    {
        Id = 19,
        Title = "The Art of Computer Programming",
        Author = "Donald Knuth",
        Category = "Computer Science",
        Year = 1968,
        Price = 150,
        IsAvailable = true
    },

    new Book
    {
        Id = 20,
        Title = "Effective C#",
        Author = "Bill Wagner",
        Category = "Programming",
        Year = 2020,
        Price = 75,
        IsAvailable = false
    }
};

    [HttpGet]
    public  ActionResult<IEnumerable<Book>> GetAllBooks()
    {
        return Ok(_books.Select(book => new
        {
            book.Id,
            book.Title
        }));
    }

   
}
