using SensorProducer.Services; 
using Microsoft.Extensions.Configuration;

var parkingFilePath = Path.Combine(AppContext.BaseDirectory, "Data", "parking-data.json");
var trafficFilePath = Path.Combine(AppContext.BaseDirectory, "Data", "traffic-data.json");
var weatherFilePath = Path.Combine(AppContext.BaseDirectory, "Data", "weather-data.json");

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

var bootstrapServer = configuration["Kafka:BootstrapServers"] ?? "localhost:9092";

var trafficTopic =
    configuration["Kafka:Topics:traffic"] ?? "traffic";

var parkingTopic =
    configuration["Kafka:Topics:parking"] ?? "parking";

var weatherTopic =
    configuration["Kafka:Topics:weather"] ?? "weather";

var dataLoad = new DataLoaderService();
var producer = new KafkaProducerService(bootstrapServer);

var parckingData = dataLoad.LoadParkingJson(parkingFilePath);
var trafficData = dataLoad.LoadTrafficReadingJson(trafficFilePath);
var weatherData = dataLoad.LoadWeatherReadingJson(weatherFilePath);

foreach (var p in parckingData)
{
    await producer.SendAsync(p, parkingTopic);
}

foreach (var t in trafficData)
{
    await producer.SendAsync(t, trafficTopic);
}

foreach (var w in weatherData)
{
    await producer.SendAsync(w, weatherTopic);
}



