using SensorProducer.Services; 
using SensorProducer.Models; 


const string bootstrapServers = "localhost:9092";
const string topicName = "sensors";

var producerService = new SensorProducerService(bootstrapServers, topicName);

var sensors = new List<Sensor>
{
    new Sensor
    {
        SensorId = "S001",
        Temperature = 24.5m,
        Timestamp = DateTime.Now
    },
    new Sensor
    {
        SensorId = "S002",
        Temperature = 27.3m,
        Timestamp = DateTime.Now
    },
    new Sensor
    {
        SensorId = "S003",
        Temperature = 19.8m,
        Timestamp = DateTime.Now
    },
    new Sensor
    {
        SensorId = "S004",
        Temperature = 31.2m,
        Timestamp = DateTime.Now
    }
};

foreach(var s in sensors)
{
    await producerService.SendOrderAsync(s); //this sends the sensor 
}