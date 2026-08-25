
using Confluent.Kafka;
using System.Text.Json;

namespace SensorProducer.Services;

public class KafkaProducerService
{
    private readonly IProducer<Null, string> _producer;

    public KafkaProducerService(string bootstrapServers)
    {
        var config = new ProducerConfig
        {
            BootstrapServers = bootstrapServers
        };

        _producer = new ProducerBuilder<Null, string>(config).Build();
     
    }

    public async Task<DeliveryResult<Null,string>> SendAsync<T>(T obj, string topicName)
    {
      
        
        var josnObj = JsonSerializer.Serialize(obj);
        var msg = new Message<Null, string>
        {
            Value = josnObj
        };


        return await _producer.ProduceAsync(topicName, msg);
        
    }

}