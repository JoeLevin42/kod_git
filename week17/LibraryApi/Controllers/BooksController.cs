using Microsoft.AspNetCore.Mvc;
using LibraryApi.Models;
using LibraryApi.Repository; 

namespace LibraryApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookRepo _bookRepo;

    public BooksController(IBookRepo bookRepo)
    {
        _bookRepo = bookRepo;
    } 

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Book>>> GetAll()
    {
        var books = await _bookRepo.GetAllAsync();
        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<Book>>> GetById(int id)
    {
        var theBook = await _bookRepo.GetByIdAsync(id);
        if (theBook == null)
        {
            return NotFound();
        }

        return Ok(theBook);
    }
    [HttpPost]
    public async Task<ActionResult<Book>> Create(Book book)
    {
        var created = await _bookRepo.CreateAsync(book);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);

     }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id , Book updatedBook)
    {
        var success = await _bookRepo.UpdateAsync(id, updatedBook);
        if (!success)
        {
            return NotFound();
        }

        return NoContent();

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _bookRepo.DeleteAsync(id);
        if (!success)
        {
            return NotFound();
        }
        return NoContent();
    }


}