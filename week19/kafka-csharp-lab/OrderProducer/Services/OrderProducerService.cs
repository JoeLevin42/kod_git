using Confluent.Kafka;
using OrderProducer.Models;
using System.Text.Json;

namespace OrderProducer.Services;

public class OrderProducerService
{
    private readonly IProducer<string, string> _producer;
    private readonly string _topicName;

    public OrderProducerService(string bootstrapServers, string topicName)
    {
        var config = new ProducerConfig
        {
            BootstrapServers = bootstrapServers,
            ClientId = "order-producer"
        };

        _producer = new ProducerBuilder<string, string>(config).Build();
        _topicName = topicName;
    }

    public async Task<DeliveryResult<string, string>> SendOrderAsync(Order order)
    {
        var key = order.OrderId.ToString();
        var value = JsonSerializer.Serialize(order);
        
        var message = new Message<string, string>
        {
            Key = key,
            Value = value
        };

        var result = await _producer.ProduceAsync(_topicName, message);

        Console.WriteLine(
            $"✓ Sent: OrderId={order.OrderId} → Partition={result.Partition}, Offset={result.Offset}");

        return result;
    }

    public void Dispose()
    {
        _producer.Flush(TimeSpan.FromSeconds(10));
        _producer.Dispose();
    }
}