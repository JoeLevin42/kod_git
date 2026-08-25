using Confluent.Kafka;
using System.Text.Json;

namespace AnalyzeProducer.Services;

public class KafkaProducer
{
    private readonly IProducer<string, string> _producer;

    public KafkaProducer(string bootstrapServers)
    {
        var config = new ProducerConfig
        {
            BootstrapServers = bootstrapServers
        };
        _producer = new ProducerBuilder<string, string>(config).Build();
    }

    public async Task ProduceSendAsync<T>(T obj , string topicName)
    {
        try
        {
            var jsonObj = JsonSerializer.Serialize(obj);
            var msg = new Message<string, string>
            {
                Value = jsonObj
            };

            await _producer.ProduceAsync(topicName ,msg);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    public async Task ProduceRawStringAsync(string message, string topic)
    {
        await _producer.ProduceAsync(
            topic,
            new Message<string, string>
            {
                
                Value = message
            });
    }
    public void Dispose()
    {
        _producer.Flush(TimeSpan.FromSeconds(10));
        _producer.Dispose();
    }

}