using Microsoft.AspNetCore.Mvc;
using UniversityApi.Models;
using MySqlConnector;

namespace UniversityApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly string _connectionString;
    public StudentsController(IConfiguration configuration)
    {
        _connectionString =

        configuration.GetConnectionString("DefaultConnection")!;
    }
    [HttpGet]
    public async Task<ActionResult<List<Student>>> GetAll()
    {
        var students = new List<Student>();
        using var connection = new MySqlConnection(_connectionString);
        await connection.OpenAsync();
        using var command = new MySqlCommand("SELECT * FROM Students",

        
        

        connection);

        using var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            students.Add(new Student
            {
                Id = reader.GetInt32("Id"),
                FullName = reader.GetString("FullName"),
                Email = reader.GetString("Email"),
                StudentNumber = reader.GetString("StudentNumber"),
                EnrolledAt = reader.GetDateTime("EnrolledAt")
            });
        }
        return Ok(students);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Student>> GetById(int id)
    {
        using var connection = new MySqlConnection(_connectionString);
        await connection.OpenAsync();
        using var command = new MySqlCommand(
        "SELECT * FROM Students WHERE Id = @id",
        connection);
        command.Parameters.AddWithValue("@id", id);
        using var reader = await command.ExecuteReaderAsync();
        if (!await reader.ReadAsync())
            return NotFound();
        var student = new Student
        {
            Id = reader.GetInt32("Id"),
            FullName = reader.GetString("FullName"),
            Email = reader.GetString("Email"),
            StudentNumber = reader.GetString("StudentNumber"),
            EnrolledAt = reader.GetDateTime("EnrolledAt")
        };
        return Ok(student);
    }
    [HttpPost]
    public async Task<ActionResult<Student>> Create(Student student)
    {
        using var connection = new MySqlConnection(_connectionString);
        await connection.OpenAsync();
        using var command = new MySqlCommand(
        @"INSERT INTO Students (FullName, Email, StudentNumber,

        EnrolledAt)

        VALUES (@fullName, @email, @studentNumber, @enrolledAt);
        SELECT LAST_INSERT_ID();",
        connection);
        command.Parameters.AddWithValue("@fullName", student.FullName);
        command.Parameters.AddWithValue("@email", student.Email);
        command.Parameters.AddWithValue("@studentNumber",

        student.StudentNumber);

        command.Parameters.AddWithValue("@enrolledAt", DateTime.UtcNow);
        var id = Convert.ToInt32(await command.ExecuteScalarAsync());
        student.Id = id;
        student.EnrolledAt = DateTime.UtcNow;
        return CreatedAtAction(nameof(GetById), new { id }, student);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Student student)
    {
        using var connection = new MySqlConnection(_connectionString);
        await connection.OpenAsync();
        using var command = new MySqlCommand(
        @"UPDATE Students
        SET FullName = @fullName, Email = @email, StudentNumber =

        @studentNumber

        WHERE Id = @id",
        connection);
        command.Parameters.AddWithValue("@id", id);
        command.Parameters.AddWithValue("@fullName", student.FullName);
        command.Parameters.AddWithValue("@email", student.Email);
        command.Parameters.AddWithValue("@studentNumber",

        student.StudentNumber);

        var rowsAffected = await command.ExecuteNonQueryAsync();
        if (rowsAffected == 0)
            return NotFound();
        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        using var connection = new MySqlConnection(_connectionString);
        await connection.OpenAsync();
        using var command = new MySqlCommand(
        "DELETE FROM Students WHERE Id = @id",
        connection);

  
command.Parameters.AddWithValue("@id", id);
        var rowsAffected = await command.ExecuteNonQueryAsync();
        if (rowsAffected == 0)
            return NotFound();
        return NoContent();
    }
}