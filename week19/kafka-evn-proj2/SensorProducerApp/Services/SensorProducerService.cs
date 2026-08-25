using Confluent.Kafka;
using static Confluent.Kafka.ConfigPropertyNames;
namespace SensorProducerApp.Services;


public class SensorProducer
{
    private readonly IProducer<string, string> _producer;
    private readonly string _topicName;
    
    public SensorProducer(string bootstrapServers, string topicName) 
        //this is simple constructor injection

    {
        var config = new ProducerConfig
        {
            BootstrapServers = bootstrapServers // inject here in config the bootstrapServers (conn string)

        };
        _producer = new ProducerBuilder<string, string>(config).Build();
        _topicName = topicName;


    }





   
}
