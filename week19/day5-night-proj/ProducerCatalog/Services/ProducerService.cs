

using Confluent.Kafka;
using System.Text.Json;
using static Confluent.Kafka.ConfigPropertyNames;


namespace ProducerCatalog.Services;

public class ProducerService
{
    private readonly IProducer<string, string> _producer;

    public ProducerService(string bootstrapServers)
    {
        var config = new ProducerConfig
        {
            BootstrapServers = bootstrapServers

        };
        _producer = new ProducerBuilder<string, string>(config).Build();
    } 

    public async Task<bool> SendProduceAsync<T>(T obj ,string topicName)
    {

        var json = JsonSerializer.Serialize(obj); //send the obj every time once
        if (json == null)
        {
            return false;
        }
        var msg = new Message<string, string>
        {
            Value = json
        };
        
        await _producer.ProduceAsync(topicName, msg);
        return true;
    }

    public async Task<bool> SendRawAsync(string message , string topicName)
    {
        var msg = new Message<string, string>
        {
            Value = message
        };
        await _producer.ProduceAsync(topicName, msg);
        return true;
    }

    public void Dispose()
    {
        _producer.Flush(TimeSpan.FromSeconds(2));
        _producer.Dispose();
    }



}