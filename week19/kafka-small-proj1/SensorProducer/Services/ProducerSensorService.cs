using SensorProducer.Models;
using Confluent.Kafka;
using System.Text.Json;

namespace SensorProducer.Services;

public class SensorProducerService
{
    private readonly IProducer<string, string> _producer;
    private readonly string _topicName;
    
    // booystrapServers is conn string
    // topicName the required name 
    public SensorProducerService(string bootstrapServers , string topicName)
    {
        var config = new ProducerConfig
        {
            BootstrapServers = bootstrapServers,
            ClientId = "Bar-Tal"
           
        };

        _producer = new ProducerBuilder<string, string>(config).Build(); // this is actually creating the producer 
        _topicName = topicName;
    }



    public async Task<DeliveryResult<string ,string >> SendOrderAsync(Sensor sensor) 
        // this actually send the msg to kafka (as dict , key[_topicname] , vlaue[msg])
    {
        var key = sensor.SensorId; // this is already str 
        var val = JsonSerializer.Serialize(sensor); //this is serialize the all model as key

        var msg = new Message<string, string> // this the msg 
        {
            Key = key, //key is the obj json
            Value = val  // the msg
        };

        return await _producer.ProduceAsync(_topicName, msg); //this is actulalyl sends to tpoic the msg

        //optinal 
    }
}