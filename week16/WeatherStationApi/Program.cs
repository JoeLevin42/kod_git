var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build(); // creates the app obj


if (app.Environment.IsDevelopment()) //Check if it the dev mode
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); //create the middlewaresswagger

app.UseAuthorization(); // make the http to https

app.MapControllers(); // creare the way to connect the url to the controller class

app.Run(); //runs the app
