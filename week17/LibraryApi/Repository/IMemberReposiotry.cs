using LibraryApi.Models;
namespace LibraryApi.Repository;

public interface IMemberRepo
{
    Task<IEnumerable<Member>> GetAllAsync();
    Task<Member?> GetByIdAsync(int id);

    Task<Member?> CreateAsync(Member Member);
    Task<bool> UpdateAsync(int id, Member member);
    Task<bool> DeleteAsync(int id);


};