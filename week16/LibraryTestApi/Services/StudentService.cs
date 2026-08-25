using LibraryTestApi.Models;
using SchoolLibraryApi.Services;
using LibraryTestApi.Repositories;



namespace SchoolLibraryApi.Services;

public class StudentService : IStudentService

{
    private readonly IBookRepository _bookRepository;
    private readonly IStudentRepository _studentRepository;

    public StudentService(IBookRepository bookRepository ,
                          IStudentRepository studentRepository)
    {
        _bookRepository = bookRepository;
        _studentRepository = studentRepository;
    }

    public async Task<IEnumerable<Student>> GetAllAsync()
    {
        var allStud = await _studentRepository.GetAllAsync();
        return allStud;
        
    }

    public async Task<Student?> GetByIdAsync(int id)
    {
        var stud = await _studentRepository.GetByIdAsync(id);
        if (stud == null)
        {
            return null;
        }
        return stud;
    }

    public async Task<Student?> CreateAsync(Student stud)
    {
        var BookExists = await _bookRepository.GetByIdAsync(stud.BookId);

        if (BookExists == null)
        {
            return null;
        }
        if (!BookExists.IsAvailable)
        {
            return null;
        }
        var allStud = await _studentRepository.GetAllAsync();

        var isBorrowed = allStud.Any(s => s.BookId == stud.BookId);
        if (isBorrowed)
        {
            return null;
        }

        await _studentRepository.AddAsync(stud);
        return stud;
    } 

    public async Task<bool> UpdateAsync(int id, Student stud)
    {
        var isUpdated = await _studentRepository.UpdateAsync(id, stud);
        return isUpdated;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var isDeleted = await _studentRepository.DeleteAsync(id);
        return isDeleted;
    }

    public async Task<bool> BorrowBookAsync(int studentId, int bookId)
    {
        var stud = await _studentRepository.GetByIdAsync(studentId);
        if (stud == null)
        {
            return false;
        }
        var book = await _bookRepository.GetByIdAsync(bookId);
        if (book == null)
        {
            return false;
        }

        if (!book.IsAvailable)
        {
            return false;
        }

        stud.BookId = bookId;
        book.IsAvailable = false;

        return true;


    }






}