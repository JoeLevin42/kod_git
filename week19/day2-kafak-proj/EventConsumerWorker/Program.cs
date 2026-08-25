using Confluent.Kafka;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EventConsumerWorker.Data;
using EventConsumerWorker.Services;
using System.Runtime.CompilerServices;

public class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("=== Smart City Event Consumer ===\n");
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json").Build();

        var services = new ServiceCollection(); //need to check what the hell is this?


        //Register the proccessing service 
        services.AddScoped<EventProcessingService>();

        var serviceProvider = services.BuildServiceProvider();
        


        // Phase 2 ||
        Console.WriteLine("Creating database...");
        using(var scope = serviceProvider.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<SmartCityDbContext>();
            db.Database.EnsureCreated();
        }

        Console.WriteLine("✓ Database ready\n");

        //||Phase 3 ||
        var consumerConfig = new ConsumerConfig
        {
            BootstrapServers = configuration["Kafka:BootstrapServers"],
            GroupId = configuration["Kafka:GroupId"],
            AutoOffsetReset = AutoOffsetReset.Earliest,
            EnableAutoCommit = false // We`ll commit manually 
        };
        using var consumer = new ConsumerBuilder<Ignore, string>(consumerConfig).Build();

        var topics = new[]
{
            configuration["Kafka:Topics:traffic"]!,
            configuration["Kafka:Topics:weather"]!,
            configuration["Kafka:Topics:parking"]!
        };

        consumer.Subscribe(topics);
        Console.WriteLine($"Subscribed to: {string.Join(", ", topics)}");
        Console.WriteLine("Consuming events... Press Ctrl+C to stop.\n");
        try
        {
            while (true)
            {
                // Wait for a message (timeout after 1 second)
                var result = consumer.Consume(TimeSpan.FromSeconds(1));

                // If no message, continue waiting
                if (result == null || result.Message?.Value == null)
                    continue;

                Console.WriteLine($"\n[{DateTime.Now:HH:mm:ss}] Received from {result.Topic}");

                // Create a new scope for this message
                // This gives us a fresh DbContext
                using (var scope = serviceProvider.CreateScope())
                {
                    var processingService = scope.ServiceProvider
                        .GetRequiredService<EventProcessingService>();

                    // Route to the correct processing method based on topic
                    bool success = result.Topic switch
                    {
                        var t when t == configuration["Kafka:Topics:traffic"]
                            => await processingService.ProcessTrafficEventAsync(result.Message.Value),
                        var t when t == configuration["Kafka:Topics:weather"]
                            => await processingService.ProcessWeatherEventAsync(result.Message.Value),
                        var t when t == configuration["Kafka:Topics:parking"]
                            => await processingService.ProcessParkingEventAsync(result.Message.Value),
                        _ => false
                    };

                    // Commit the offset (tell Kafka we processed this message)
                    if (success)
                    {
                        consumer.Commit(result);
                    }
                    else
                    {
                        Console.WriteLine("⚠ Processing failed, but committing to avoid reprocessing");
                        consumer.Commit(result);
                    }
                }
            }
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("\n\nShutting down gracefully...");
        }
        finally
        {
            consumer.Close();
            Console.WriteLine("Consumer closed.");
        }
    }
}

   
