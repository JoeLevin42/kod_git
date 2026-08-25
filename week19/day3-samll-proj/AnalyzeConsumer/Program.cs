using AnalyzeConsumer.Data;
using AnalyzeConsumer.Services;
using Confluent.Kafka;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    static async Task Main(string[] args)
    {
        //part 1 -- register the dbcontext , configuration object (for settings.json)
        // and create the DI

        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();



        var services = new ServiceCollection();
        services.AddScoped<EventProcessingService>();
      
        //later add here the process service

        var connectionString = configuration["ConnectionStrings:DefaultConnection"];
        services.AddDbContext<ApplicationDbContext>(
           dbContextOptions => dbContextOptions
               .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        var serviceProvider = services.BuildServiceProvider();

        using (var serviceScope = serviceProvider.CreateScope())
        {
            var db = serviceProvider.GetRequiredService<ApplicationDbContext>();
            db.Database.EnsureCreated();
        }

        //||
        // until here this is the configuraion of the DI!!!
        //||
        //Creating the consumer

        //first configureate and then inject the config into the consomer object

        var config = new ConsumerConfig
        {
            BootstrapServers = configuration["Kafka:BootstrapServers"],
            GroupId = configuration["Kafka:GroupId"],
            AutoOffsetReset = AutoOffsetReset.Earliest 
            //right this is automatic
        };
        var consumer = new ConsumerBuilder<Ignore, string>(config).Build();

        // ============================================
        // STEP 1: Read Analysts
        // ============================================

        consumer.Subscribe(configuration["Kafka:Topics:Analysts"]);

        Console.WriteLine("Consuming Analysts...");

        while (true)
        {
            var result = consumer.Consume();

            if (result?.Message?.Value == null)
                continue;

            Console.WriteLine($"Received: {result.Message.Value}");

            // IMPORTANT: check the special message BEFORE deserializing
            if (result.Message.Value == "END_ANALYSTS")
            {
                Console.WriteLine("All analysts received.");
                break;
            }

            using var scope = serviceProvider.CreateScope();

            var processingService = scope.ServiceProvider
                .GetRequiredService<EventProcessingService>();

            await processingService.ProcessAnalysts(result.Message.Value);

            consumer.Commit(result);

            Console.WriteLine($"Analyst processed: {result.Message.Value}");
        }

        consumer.Unsubscribe();

        consumer.Subscribe(configuration["Kafka:Topics:Calls"]);

        Console.WriteLine("Consuming Calls...");

        while (true)
        {
            var result = consumer.Consume();

            using var scope = serviceProvider.CreateScope();

            var processingService = scope.ServiceProvider
                .GetRequiredService<EventProcessingService>();

            await processingService.ProcessCalls(result.Message.Value);

            consumer.Commit(result);

            Console.WriteLine($"Call: {result.Message.Value}");
        }

    }



    
}