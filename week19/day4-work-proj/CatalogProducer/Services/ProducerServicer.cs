
using Confluent.Kafka;
using System.Text.Json;

namespace CatalogProducer.Services;

public class ProducerServicer
{
    private readonly IProducer<string, string> _producer;

    public ProducerServicer(string bootstrapSevers)
    {
        var config = new ProducerConfig
        {
            BootstrapServers = bootstrapSevers
        };
    _producer = new ProducerBuilder<string, string>(config).Build();
    }

    public async Task SendProduceAsync<T>(T obj , string topicName)
    {
        var jsonMsg = JsonSerializer.Serialize(obj);

        var msg = new Message<string, string>
        {
            Value = jsonMsg
        };

        await _producer.ProduceAsync(topicName,msg);
    }

    public async Task SendRawAsync(string message, string topicName)
    {

        var msg = new Message<string, string>
        {
            Value = message
        };

        await _producer.ProduceAsync(topicName, msg);
    }

    public void Dispose()
    {
        _producer.Flush(TimeSpan.FromSeconds(2));
        _producer.Dispose();
    }
       


}