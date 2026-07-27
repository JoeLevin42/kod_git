
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); //Create the reflection run time to find the controllers
builder.Services.AddSwaggerGen(); //this gernrating the swagger

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();