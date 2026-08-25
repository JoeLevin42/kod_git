using BlogApi2.Data;
using BlogApi2.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApi2.Repository;

public class PostRepostiry 
{
    private readonly ApplicationDbContext _context;

    public PostRepostiry(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Post>> GetAllAsync()
    {
        var allPosts = await _context.Posts
                        .Include(e => e.Author)
                        .Include(e => e.Comments)
                        .ToListAsync();
        return allPosts;
    }

    public async Task<IEnumerable<Post>> GetFilteredAsync(int? AuthorId , 
                    DateTime? from , DateTime? to)
    {
        var query = await _context.Posts.AsQueryable();
        query = 
                    
                    
    }


}