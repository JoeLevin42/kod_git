using BlogApi.Data;
using BlogApi.Models;
using BlogApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace BlogApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostController : ControllerBase
{
    private readonly IPostRepostiory _postRepo;
    public PostController(IPostRepostiory postRepo)
    {
        _postRepo = postRepo;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Post>>> GetAllWithRealatedAsync()
    {
        var all = await _postRepo.GetAllWithAllRelatedAsync();
        return Ok(all);

    }

    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<Post>>> SearchOptionalAsync(int? authorId,
                DateTime? from, DateTime? to)
    {
        var all = await _postRepo.SearchOptionalAsync(authorId, from, to);
        return Ok(all);
    }
    [HttpGet("sort")]
    public async Task<ActionResult<IEnumerable<Post>>> SoryDynamicAsync(string? sortBy, bool desc = false)
    {
        var all = await _postRepo.SoryDynamicAsync(sortBy, desc);
        return Ok(all);
    }

    [HttpGet("stats")]
    public async Task<ActionResult<IEnumerable<object>>> GetStatsAsync()
    {
        var all = await _postRepo.GetStatsAsync();
        return Ok(all);
    }

    [HttpGet("some")]
    public async  Task<ActionResult<IEnumerable<object>>> GetSomethingAsync()
    {
        var all = await _postRepo.GetSomethingAsync();
        return Ok(all);
    }

    [HttpGet("some2")]
    public async Task<ActionResult<IEnumerable<object>>> GetSomething2Async()
    {
        var all = await _postRepo.GetSomething2Async();
        return Ok(all);
    }
    [HttpGet("page")]
    public async Task<ActionResult<IEnumerable<object>>> PageAsync(int page, int pageSize)
    {
       var all =  await _postRepo.GetPagedAsync(page, pageSize);
        return Ok(all);
    }

   
} 