using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NightConsumer.Data;
using NightConsumer.Services;
using Confluent.Kafka;



var configuration =  new ConfigurationBuilder().SetBasePath(Directory
    .GetCurrentDirectory()).AddJsonFile("appsettings.json").Build(); //The build actualyy waking the obj

var services = new ServiceCollection(); //create the blue pring

var connectionString = configuration["ConnectionStrings:DefaultConnection"];

//reginster mysql 
services.AddDbContext<ApplicationDbContext>(
           dbContextOptions => dbContextOptions
               .UseMySql(connectionString,
               ServerVersion.AutoDetect(connectionString))); // register the db conetxt to the services container

services.AddScoped<Proccessor>(); // register the proccesor service

var serviceProvider = services.BuildServiceProvider(); // this is the actual provider off the services

/// the basic-config until here -----
/// now need to create the scoped ensure()
/// 

using (var scoped = serviceProvider.CreateScope())
{
    //var scopedService = scoped.ServiceProvider;
    var dependency = serviceProvider.GetRequiredService<ApplicationDbContext>();
    dependency.Database.EnsureCreated();
}
//!!! here we created the database alone


var config = new ConsumerConfig
{
    BootstrapServers = configuration["Kafka:BootstrapServers"] ?? "localhost:9092",
    GroupId = configuration["Kafka:GroupId"] ?? "some-group",
    AutoOffsetReset = AutoOffsetReset.Earliest 
    // we dont off the commit (because its not matter here but optional = autoCommit = false)
    
};

using var consumer = new ConsumerBuilder<Ignore, string>(config).Build(); // the actual consumer obj

//now we reached to the loop the main issue here!!

var analystsTopic = configuration["Kafak:Topics:Analysts"] ?? "Analysts";

consumer.Subscribe(analystsTopic);


while (true)
{
    var result = consumer.Consume();
   
    if (result?.Message?.Value == null)
    {
        continue;
    }

    Console.WriteLine($"Check the msg {result.Message.Value}");

    //Check the END word


    if (result.Message.Value == "END-ANALYSTS")
    {
        Console.WriteLine("End to get the Analysts");
        break;
    }
    using var scoped = serviceProvider.CreateScope();

    var proccessor = scoped.ServiceProvider.GetRequiredService<Proccessor>();
    await proccessor.ProccessAnalysts(result.Message.Value);

    consumer.Commit(result);
    Console.WriteLine($"Analysts proccessed {result.Message.Value}");
}

consumer.Unsubscribe();
var callsTopic = configuration["Kafak:Topics:Calls"] ?? "Calls";

consumer.Subscribe(callsTopic);


while (true)
{
    var result = consumer.Consume();

    if (result?.Message?.Value == null)
    {
        continue;
    }

    using var scoped = serviceProvider.CreateScope();
    var proccessor = scoped.ServiceProvider.GetRequiredService<Proccessor>();
    await proccessor.ProccessCalls(result.Message.Value);

    consumer.Commit(result);

    Console.WriteLine($"Calls have been proccessed {result.Message.Value}");
}



