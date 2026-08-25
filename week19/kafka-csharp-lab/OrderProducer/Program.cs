using OrderProducer.Models;
using OrderProducer.Services;
const string bootstrapServers = "localhost:9092"; 
const string topicName = "orders";

Console.WriteLine("=== Order Producer ===\n");

// Step 1: Ensure topic exists
//var topicManager = new KafkaTopicManager(bootstrapServers); not needed "bar -tal" 
//await topicManager.EnsureTopicExistsAsync(topicName); ,,

Console.WriteLine();

// Step 2: Create sample orders
var orders = new[]
{
    new Order
    {
        OrderId = 101,
        CustomerName = "Alice",
        Amount = 250.50m
    },
    new Order
    {
        OrderId = 102,
        CustomerName = "Bob",
        Amount = 120.00m
    },
    new Order
    {
        OrderId = 103,
        CustomerName = "Charlie",
        Amount = 340.75m
    }
};

// Step 3: Send orders to Kafka
var producerService = new OrderProducerService(
    bootstrapServers,
    topicName);

foreach (var order in orders)
{
    await producerService.SendOrderAsync(order);
}

producerService.Dispose();

Console.WriteLine("\n✓ All orders sent successfully.");