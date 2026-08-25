

using Confluent.Kafka;
using ConsumerCatalog.Data;
using ConsumerCatalog.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

//need to create the DI container
//
var services = new ServiceCollection();
//here need to registre db conetxt and the proccessor services

var conString = configuration.GetConnectionString("DefaultConnection");
services.AddDbContext<ApplicationDbContext>(
            dbContextOptions => dbContextOptions
                .UseMySql(conString, ServerVersion.AutoDetect(conString))); //context registration
services.AddScoped<ProccessorService>();


var serviceProvider = services.BuildServiceProvider();

//create the service with db creatin

using (var scoped = serviceProvider.CreateScope())
{
    var dependency = scoped.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dependency.Database.EnsureCreated();

}
//this was actualy scoping the dbContext crating migrations;

//now need to configure kafka!!


var bootsrapServers = configuration["Kafka:BootstrapServers"] ?? "localhost:9092";
var groupId = configuration["Kafka:GroupId"] ?? "some-group44";
var config = new ConsumerConfig
{
    BootstrapServers = bootsrapServers,
    GroupId = groupId,
    AutoOffsetReset = AutoOffsetReset.Earliest
};

using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();

//until here the creation now the while loop

var uavTopic = configuration["Kafka:Topics:uav"] ?? "uav";
consumer.Subscribe(uavTopic);

while (true)
{
    var res = consumer.Consume();

    if (res?.Message?.Value == null)
    {
        continue;
    }

    if (res.Message.Value== "END_UAV")
    {
        Console.WriteLine("Finsed to consume UAV");
        break;
    }

    //now crateing scope for proccesoor service
    using var scope = serviceProvider.CreateScope();
    var proccessor = serviceProvider.GetRequiredService<ProccessorService>();
    await proccessor.ProccessUavAsync(res.Message.Value);
    // this is actual doing the thing
    Console.WriteLine($"Proccess TO DB {res.Message.Value}");
    consumer.Commit(res); //for the offSet very inportant that commit will hold res
}

//after first loop after break
consumer.Unsubscribe();
//now next topic
var hostileTopic = configuration["Kafka:Topics:hostileUnits"] ?? "hostileUnits";

consumer.Subscribe(hostileTopic);
while (true)
{
    var res = consumer.Consume();

    if (res?.Message?.Value == null)
    {
        continue;
    }

    if (res.Message.Value == "END_HOSTILES")
    {
        Console.WriteLine("Finsed to consume HOSTILE");
        break;
    }

    //now crateing scope for proccesoor service
    using var scope = serviceProvider.CreateScope();
    var proccessor = serviceProvider.GetRequiredService<ProccessorService>();
    await proccessor.ProccessHotileUnitAsync(res.Message.Value);
    // this is actual doing the thing
    Console.WriteLine($"Proccess TO DB {res.Message.Value}");
    consumer.Commit(res); //for the offSet very inportant that commit will hold res
}

//next loop 

consumer.Unsubscribe();

var tracksTopic = configuration["Kafka:Topics:tracks"] ?? "tracks";

consumer.Subscribe(tracksTopic);


while (true)
{
    var res = consumer.Consume();

    if (res?.Message?.Value == null)
    {
        continue;
    }

    //now crateing scope for proccesoor service
    using var scope = serviceProvider.CreateScope();
    var proccessor = serviceProvider.GetRequiredService<ProccessorService>();
    await proccessor.ProccessTrackAsync(res.Message.Value);
    // this is actual doing the thing
    Console.WriteLine($"Proccess TO DB {res.Message.Value}");
    consumer.Commit(res); //for the offSet very inportant that commit will hold res
}



