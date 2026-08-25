using Confluent.Kafka;
using OrdersApi.Models;
using System.Text.Json;

namespace OrdersApi.Services;

public class KafkaConsumerService
{
    private readonly IConsumer<string, string> _consumer;
    private readonly string _topicName;

    public KafkaConsumerService(IConfiguration configuration)
    {
        var bootstrapServers =
            configuration["Kafka:BootstrapServers"] ?? "localhost:9092";

        var groupId =
            configuration["Kafka:GroupId"] ?? "orders-api-group";

        _topicName =
            configuration["Kafka:TopicName"] ?? "orders";

        var config = new ConsumerConfig
        {
            BootstrapServers = bootstrapServers,
            GroupId = groupId,
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        _consumer = new ConsumerBuilder<string, string>(config).Build();

        _consumer.Subscribe(_topicName);

        Console.WriteLine(
            $"✓ Kafka Consumer subscribed to topic '{_topicName}' with GroupId '{groupId}'"
        );
    }

    public Order? ConsumeNextOrder(TimeSpan timeout)
    {
        try
        {
            var consumeResult = _consumer.Consume(timeout);

            if (consumeResult == null || consumeResult.IsPartitionEOF)
            {
                return null;
            }

            var order = JsonSerializer.Deserialize<Order>(
                consumeResult.Message.Value
            );

            Console.WriteLine(
                $"✓ Consumed: OrderId={order?.OrderId} " +
                $"from Partition={consumeResult.Partition}, " +
                $"Offset={consumeResult.Offset}"
            );

            return order;
        }
        catch (ConsumeException ex)
        {
            Console.WriteLine(
                $"✗ Error consuming message: {ex.Error.Reason}"
            );

            return null;
        }
    }
}