using LibraryTestApi.Models;

namespace SchoolLibraryApi.Services;

public interface IStudentService
{
    // CRUD

    Task<IEnumerable<Student>> GetAllAsync();

    Task<Student?> GetByIdAsync(int id);

    Task<Student?> CreateAsync(Student student);

    Task<bool> UpdateAsync(int id, Student student);

    Task<bool> DeleteAsync(int id);



    // Business Logic

    Task<bool> BorrowBookAsync(int studentId, int bookId);

}