using LibraryTestApi.Models;

namespace LibraryTestApi.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly List<Student> _students;
    private int _nextId;

    public StudentRepository()
    {
        _students = new List<Student>
        {
            new Student
            {
                Id = 1,
                Name = "Yael Cohen",
                Grade = "11",
                BookId = 2,
                BorrowDate = new DateTime(2024, 1, 15)
            },
            new Student
            {
                Id = 2,
                Name = "David Levi",
                Grade = "12",
                BookId = 5,
                BorrowDate = new DateTime(2024, 1, 20)
            },
            new Student
            {
                Id = 3,
                Name = "Maya Shapiro",
                Grade = "10",
                BookId = 2,
                BorrowDate = new DateTime(2024, 2, 5)
            },
            new Student
            {
                Id = 4,
                Name = "Noam Israeli",
                Grade = "11",
                BookId = 9,
                BorrowDate = new DateTime(2024, 2, 10)
            },
            new Student
            {
                Id = 5,
                Name = "Tamar Mizrahi",
                Grade = "12",
                BookId = 1,
                BorrowDate = new DateTime(2024, 2, 14)
            },
            new Student
            {
                Id = 6,
                Name = "Omer Ben-David",
                Grade = "10",
                BookId = 1,
                BorrowDate = new DateTime(2024, 2, 20)
            },
            new Student
            {
                Id = 7,
                Name = "Shira Katz",
                Grade = "11",
                BookId = 1,
                BorrowDate = new DateTime(2024, 3, 1)
            },
            new Student
            {
                Id = 8,
                Name = "Eitan Goldberg",
                Grade = "12",
                BookId = 5,
                BorrowDate = new DateTime(2024, 3, 5)
            },
            new Student
            {
                Id = 9,
                Name = "Noa Friedman",
                Grade = "10",
                BookId = 9,
                BorrowDate = new DateTime(2024, 3, 10)
            }
        };

        _nextId = _students.Max(s => s.Id) + 1;
    }

    public async Task<IEnumerable<Student>> GetAllAsync()
    {
        await Task.Delay(10);

        return _students;
    }

    public async Task<Student?> GetByIdAsync(int id)
    {
        await Task.Delay(10);
        var stud = _students.FirstOrDefault(s => s.Id ==id);

        return stud;
    }

    public async Task<Student?> AddAsync(Student student)
    {
        await Task.Delay(10);
        student.Id = _nextId++;
        _students.Add(student);

        return student;
    }

    public async Task<bool> UpdateAsync(int id , Student updatedStudent)
    {
        await Task.Delay(10);
        var existsStud = _students.FirstOrDefault(s => s.Id == id);
        if (existsStud == null)
        {
            return false;
        }
        existsStud.Name = updatedStudent.Name;
        existsStud.Grade = updatedStudent.Grade;
        existsStud.BookId = updatedStudent.BookId;
        existsStud.BorrowDate = updatedStudent.BorrowDate;
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        await Task.Delay(10);
        var existsStud = _students.FirstOrDefault(s => s.Id == id);
        if (existsStud == null)
        {
            return false;
        }
        _students.Remove(existsStud);
        return true;


    }
    



}