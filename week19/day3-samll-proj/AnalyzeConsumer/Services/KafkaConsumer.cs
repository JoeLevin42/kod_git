using Confluent.Kafka;

namespace AnalyzeConsumer.Services;

public class KafkaConsumer
{
    private readonly IConsumer<string, string> _consumer;

   public KafkaConsumer(string bootstrapServers)
    {
        var config = new ConsumerConfig
        {
            BootstrapServers = bootstrapServers

        };
    }
}