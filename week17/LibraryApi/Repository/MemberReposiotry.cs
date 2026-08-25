using Microsoft.EntityFrameworkCore;
using LibraryApi.Data;
using LibraryApi.Models;

namespace LibraryApi.Repository;

public class MemberRepository : IMemberRepo
{
    private readonly ApplicationDbContext _context;
    public MemberRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Member>> GetAllAsync()
    {
        return await _context.Member.ToListAsync();
    }

    public async Task<Member?> GetByIdAsync(int id)
    {
        return await _context.Member.FindAsync(id);
    }

    public async Task<Member?> CreateAsync(Member member)
    {

        _context.Member.Add(member);
        await _context.SaveChangesAsync();
        return member;
    }

    public async Task<bool> UpdateAsync(int id, Member updatedMember)
    {
        var exists = await _context.Member.FindAsync(id);
        if (exists == null)
        {
            return false;
        }

        exists.FullName = updatedMember.FullName;
        exists.Email = updatedMember.Email;
        exists.MembershipNumber = updatedMember.MembershipNumber;
        exists.JoinedDate = updatedMember.JoinedDate;


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
