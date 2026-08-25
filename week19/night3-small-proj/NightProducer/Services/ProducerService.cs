
using Confluent.Kafka;
using System.Text.Json;

namespace NightProducer.Services;

public class ProducerService
{
    private readonly IProducer<string, string> _producer;

    public ProducerService(string bootstrapServers)
    {
        var config = new ProducerConfig
        {
            BootstrapServers = bootstrapServers
        };

        _producer = new ProducerBuilder<string,string>(config).Build(); //hey we creatn until here working producer obj!
    }

    public async Task SendAsync<T>(T jsonObj , string topicName)
    {
        try
        {
            var json = JsonSerializer.Serialize(jsonObj);
            var msg = new Message<string, string>
            {
                Value = json
            };
            await _producer.ProduceAsync(topicName, msg);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public async Task SendRawMsg<T>(T message , string topicName)
    {
        
        var msg = new Message<string, string>
        {
            Value = message.ToString()
        };

        await _producer.ProduceAsync(topicName, msg);
    }
    
    public void Dispose()
    {
        _producer.Flush(TimeSpan.FromSeconds(10));
        _producer.Dispose();
    }



}