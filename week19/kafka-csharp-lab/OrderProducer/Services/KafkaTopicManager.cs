using Confluent.Kafka;
using Confluent.Kafka.Admin;

namespace OrderProducer.Services;

public class KafkaTopicManager
{
    private readonly string _bootstrapServers;

    public KafkaTopicManager(string bootstrapServers)
    {
        _bootstrapServers = bootstrapServers;
    }

    public async Task EnsureTopicExistsAsync(
        string topicName,
        int numPartitions = 1,
        short replicationFactor = 1)
    {
        var config = new AdminClientConfig
        {
            BootstrapServers = _bootstrapServers
        };

        using var adminClient = new AdminClientBuilder(config).Build();

        try
        {
            await adminClient.CreateTopicsAsync(
                new[]
                {
                    new TopicSpecification
                    {
                        Name = topicName,
                        NumPartitions = numPartitions,
                        ReplicationFactor = replicationFactor
                    }
                });

            Console.WriteLine(
                $"✓ Topic '{topicName}' created successfully.");
        }
        catch (CreateTopicsException e)
        {
            if (e.Results[0].Error.Code == ErrorCode.TopicAlreadyExists)
            {
                Console.WriteLine(
                    $"✓ Topic '{topicName}' already exists.");
            }
            else
            {
                throw new Exception(
                    $"Failed to create topic: {e.Results[0].Error.Reason}");
            }
        }
    }
}