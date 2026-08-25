using MongoDB.Driver;
using simpleProj.Models;
using simpleProj.Repo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString =
    builder.Configuration["MongoConnectionString"];

var databaseName =
    builder.Configuration["MongoDatabase"];


var client = new MongoClient(connectionString);

var database = client.GetDatabase(databaseName);

var products =
    database.GetCollection<Product>("products");
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddSingleton(products);

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
