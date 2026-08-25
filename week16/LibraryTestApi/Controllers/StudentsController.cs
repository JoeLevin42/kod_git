using Microsoft.AspNetCore.Mvc;
using SchoolLibraryApi.Services;
using LibraryTestApi.Models;


namespace LibraryTestApi.Controllers;


[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IStudentService _studService;

    public StudentsController(IStudentService studService)
    {
        _studService = studService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Student>>> GetAllAsync()
    {
        var allStud =  await _studService.GetAllAsync();
        return Ok(allStud);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Student>> GetByIdAsync(int id)
    {
        var theStud = await _studService.GetByIdAsync(id);
        if (theStud == null)
        {
            return NotFound();
        }

        return Ok(theStud);
    }

    [HttpPost]
    public async Task<ActionResult<Student>> CreateAsync(Student stud)
    {
        var createdStud = await _studService.CreateAsync(stud);
        if (createdStud == null)
        {
            return BadRequest();
        }

        return CreatedAtAction("GetById", new { id = createdStud.Id }, createdStud);
    }

    [HttpPost("{studId}/borrow/{bookId}")]
    public async Task<IActionResult> BorrowAsync(int studId, int bookId)
    {
        var result = await _studService.BorrowBookAsync(studId, bookId);
        if (!result)
        {
            return BadRequest();
        }
        return Created();
    }
}