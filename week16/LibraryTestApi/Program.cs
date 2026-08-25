
using LibraryTestApi.Repositories;
using LibraryTestApi.Services;
using SchoolLibraryApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSingleton< IStudentRepository, StudentRepository>();
builder.Services.AddSingleton< IBookRepository, BookRepository>();
builder.Services.AddScoped< IBookService, BookService>();
builder.Services.AddScoped< IStudentService, StudentService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
