using Microsoft.EntityFrameworkCore;
using BlogApi.Models;
using BlogApi.Data;
namespace BlogApi.Repository;

public interface IPostRepostiory
{
    Task<IEnumerable<Post>> GetAllWithAllRelatedAsync();
    Task<IEnumerable<Post>> SearchOptionalAsync(int? authorId,
                DateTime? from, DateTime? to);
    Task<IEnumerable<Post>> SoryDynamicAsync(string? sortBy, bool desc = false);
    Task<IEnumerable<object>> GetStatsAsync();
    Task<IEnumerable<object>> GetSomethingAsync();
    Task<IEnumerable<object>> GetSomething2Async();
    Task<IEnumerable<Post>> GetPagedAsync(int page, int pageSize);

}