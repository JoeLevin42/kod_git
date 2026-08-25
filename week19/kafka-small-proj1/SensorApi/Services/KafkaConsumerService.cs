using Confluent.Kafka;
using SensorApi.Models;
using System.Text.Json;
namespace SensorApi.Services;

public class KafkaConsumerService
{
    private readonly IConsumer<string, string> _consumer;
    private readonly string _topicName; //very important know for to add 

    public KafkaConsumerService(IConfiguration config)
    {
        var bootstrapServers =
            config["Kafka:BootstrapServers"] ?? "localhost:9092";
        var GroupId =
            config["Kafka:GroupId"] ?? "sensors-api-group";

        _topicName =
            config["Kafka:TopicName"] ?? "sensors"; //this is the most basi configuration to do!!

        var configuration = new ConsumerConfig
        {
            BootstrapServers = bootstrapServers,
            GroupId = GroupId,
            AutoOffsetReset = AutoOffsetReset.Earliest //optional!!!
        };

        _consumer = new ConsumerBuilder<string, string>(configuration).Build();
        //this is actully creating the consumer
        _consumer.Subscribe(_topicName);
        //this is  actually tell the consumer to actually
    }
        public Sensor? ConsumeNextSensor(TimeSpan timeout)
    {
        try
        {
            var consumeResult = _consumer.Consume(timeout); //this is actually takes the message with the dely (timeout)

            if (consumeResult == null)
            {
                return null;
            }
            var sensor = JsonSerializer.Deserialize<Sensor>(consumeResult.Message.Value);
            
            return sensor;
        }
        catch (ConsumeException ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

}

