//start the first part 1 -- version
// to to create the DI
using CatalogConsumer.Data;
using CatalogConsumer.Services;
using Confluent.Kafka;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

//create basic config - and DI container
var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json").Build();

var services = new ServiceCollection();

var connectionString = configuration.GetConnectionString("DefaultConnection");

services.AddDbContext<ApplicationDbContext>(
            dbContextOptions => dbContextOptions
                .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

services.AddScoped<Proccessor>(); // this is only regisrartion where im creating the scope

var serviceProvider = services.BuildServiceProvider();

//until here the simple config of DI
//now we need to create the db service scoped!!

using (var serviceScope = serviceProvider.CreateScope())
{
    var dependency = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dependency.Database.EnsureCreated();
}
//====================================
//until here this is the The creation of DI and scoped the DbConetxt
// very important to remember that we need to scope here the dbConext (beacuse we only register it b u never scoped

var config = new ConsumerConfig
{
    BootstrapServers = configuration["Kafka:BootstrapServers"] ?? "localhost:9092",
    GroupId = configuration["Kafka:GroupId"] ?? "some-group1",
    AutoOffsetReset = AutoOffsetReset.Earliest
};
using var consumer = new ConsumerBuilder<Ignore, string>(config).Build() ;
// part 4 the while loop 

var uavTopic = configuration["Kafka:uav"] ?? "uav";
consumer.Subscribe(uavTopic);
while (true)
{
    var result = consumer.Consume();

    if (result?.Message?.Value == null)
    {
        continue;
    }

    if (result?.Message?.Value == "END_UAV") //this is the 
    {
        Console.WriteLine("Finised procces UAV....");
        break;
    }

    using var scopedService = serviceProvider.CreateScope();
    var proccessor = serviceProvider.GetRequiredService<Proccessor>();
    await proccessor.ProccessUavAsync(result.Message.Value);
    Console.WriteLine($"proccesed TO DB {result?.Message?.Value}");

    consumer.Commit(result);
}

consumer.Unsubscribe();
//next topic -- HostileUnits
var hostileTopic = configuration["Kafka:Topics:hostile"] ?? "hostile";
consumer.Subscribe(hostileTopic);

while (true)
{
    var result = consumer.Consume();

    if (result?.Message?.Value==null)
    {
        continue;
    }

    if (result?.Message?.Value == "END_HOSTILE")
    {
        Console.WriteLine("Finsed the Hostile......");
        break;
    }

    using var scopedService = serviceProvider.CreateScope();
    var proccessor = serviceProvider.GetRequiredService<Proccessor>();
    await proccessor.ProccessHostileUnitAsync(result?.Message?.Value);
    Console.WriteLine($"Proccessed TO DB {result?.Message?.Value}");

    consumer.Commit(result);

}
// now unsubsribing and goes to the next 
consumer.Unsubscribe();

var tracksTopic = configuration["Kafka:Topics:tracks"] ?? "tracks";

consumer.Subscribe(tracksTopic);

while (true)
{
    var result = consumer.Consume();

    if (result?.Message?.Value==null)
    {
        continue;
    }

    using var scoped = serviceProvider.CreateScope();
    var proccessor = serviceProvider.GetRequiredService<Proccessor>();
    await proccessor.ProccessTrackAsync(result?.Message?.Value);
    Console.WriteLine($"Proccessed TO DB {result?.Message?.Value}");

    consumer.Commit(result);
}


