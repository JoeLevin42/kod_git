//fist craste the configuration obj that reads from appsettings.json
using CatalogProducer.Services;
using Microsoft.Extensions.Configuration;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

var tracksPath = Path.Combine(AppContext.BaseDirectory, "Data", "tracks.json");
var hostileUnitsPath = Path.Combine(AppContext.BaseDirectory, "Data", "hostile_units.json");
var uavPath = Path.Combine(AppContext.BaseDirectory , "Data", "uav_models.json");

var bootstrapServers = configuration["Kafka:BootstrapServers"] ?? "localhost:9092";
var tracksTopic = configuration["Kafak:Topics:tracks"] ?? "tracks";
var hostileTopic = configuration["Kafak:Topics:hostile"] ?? "hostile";
var uavTopic = configuration["Kafak:Topics:uav"] ?? "uav";

var jsonLoader = new JsonLoaderService();
var producer = new ProducerServicer(bootstrapServers);

var tracksData = jsonLoader.LoadFromJson<object>(tracksPath);
var hostileData = jsonLoader.LoadFromJson<object>(hostileUnitsPath);
var uavData = jsonLoader.LoadFromJson<object>(uavPath);



foreach (var u in uavData)
{
    await producer.SendProduceAsync(u,uavTopic);
}
//end for uav
await producer.SendRawAsync("END_UAV", uavTopic);
Console.WriteLine("End for UAV");

foreach (var h in hostileData)
{
    await producer.SendProduceAsync(h, hostileTopic);
}
await producer.SendRawAsync("END_HOSTILE", hostileTopic);
Console.WriteLine("End for hostile");

foreach (var t in tracksData)
{
    await producer.SendProduceAsync(t, tracksTopic);
}

Console.WriteLine("End for tracks");
producer.Dispose();