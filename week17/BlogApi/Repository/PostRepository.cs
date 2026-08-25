using Microsoft.EntityFrameworkCore;
using BlogApi.Models;
using BlogApi.Data;

namespace BlogApi.Repository;
public class PostRepository : IPostRepostiory
{
    private readonly ApplicationDbContext _context;

    public PostRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    //LINQ 1 LOAD ALL
    public async Task<IEnumerable<Post>> GetAllWithAllRelatedAsync()
    {
        return await _context.Posts
            .Include(p => p.Author)
            .Include(p => p.Comments)
            .ToListAsync();

    }
    // LINQ 2 FILTER OPTIONAL
    public async Task<IEnumerable<Post>> SearchOptionalAsync(int? authorId,
            DateTime? from, DateTime? to)
    {
        var query = _context.Posts.AsQueryable();

        query = query.Where(p => p.IsPublished);

        if (authorId != null)
        {
            query = query.Where(p => p.AuthorId == authorId);
        }
        if (from != null)
        {
            query = query.Where(p => p.PublishedDate >= from);
        }
        if (to != null)
        {
            query = query.Where(p => p.PublishedDate <= to);
        }


        return await query.ToListAsync();
    }
    //LINQ 3 -- SORT OPTIONAL

    public async Task<IEnumerable<Post>> SoryDynamicAsync(string? sortBy, bool desc = false)
    {
        var query = _context.Posts.AsQueryable();

        sortBy = sortBy?.ToLower();

        if (sortBy != null)
        {
            if (sortBy == "publisheddate")
            {
                if (desc)
                {
                    query = query.OrderByDescending(p => p.PublishedDate);
                }
                else
                {
                    query = query.OrderBy(p => p.PublishedDate);
                }
            }

            if (sortBy == "title")
            {
                if (desc)
                {
                    query = query.OrderByDescending(p => p.Title);
                }
                else
                {
                    query = query.OrderBy(p => p.Title);
                }
            }

        }
        return await query.ToListAsync();
    }

    public async Task<IEnumerable<object>> GetStatsAsync()
    {
        var allPosts = _context.Posts.AsQueryable();

        var results = allPosts.Select(p => new
        {
            Id = p.Id,
            Title = p.Title,
            CommentsCount = p.Comments.Count(),

        });

        return await results.ToListAsync();


    }

    public async Task<IEnumerable<object>> GetSomethingAsync()
    {
        var all = _context.Author.AsQueryable();

        var res =  all.Select(p => new
        {
            Id = p.Id,
            PostCount = p.Posts.Count()
        }
        ).ToListAsync();

        return await res;
    }

    public async Task<IEnumerable<object>> GetSomething2Async()
    {
        var all = _context.Author.AsQueryable();

        var res = all.Select(p =>
        new
        {
            Id = p.Id,
            CommentCount = p.Posts.SelectMany(p => p.Comments).Count()
        });

        return await res.ToListAsync();

    }

    public async Task<IEnumerable<Post>> GetPagedAsync(int page , int pageSize)
    {
        return await _context.Posts
            .OrderBy(p=>p.Id)
            .Include(p => p.Author)
            .Include(p => p.Comments)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }




}