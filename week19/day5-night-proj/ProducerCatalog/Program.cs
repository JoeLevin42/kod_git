using ProducerCatalog.Services;
using Microsoft.Extensions.Configuration;

var configuration = new ConfigurationBuilder().
    SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

var uavPath = Path.Combine(AppContext.BaseDirectory, "Data", "uav_models.json");
var hostileUnitsPath = Path.Combine(AppContext.BaseDirectory, "Data", "hostile_units.json");
var tracksPath = Path.Combine(AppContext.BaseDirectory, "Data", "tracks.json");

var bootstrapServers = configuration["Kafak:BootstrapServers"] ?? "localhost:9092";
var uavTopic = configuration["Kafka:Topics:uav"] ?? "uav";
var hostileUnitsTopic = configuration["Kafka:Topics:hostileUnits"] ?? "hostileUnits";
var tracksTopic = configuration["Kafka:Topics:tracks"] ?? "tracks";

var jsonLoader = new JsonLoaderService();
var producer = new ProducerService(bootstrapServers);

//now load the data

var uavData = jsonLoader.LoadFromJson<object>(uavPath);
var hostileUnitsData = jsonLoader.LoadFromJson<object>(hostileUnitsPath);
var tracksData = jsonLoader.LoadFromJson<object>(tracksPath);

//now loop by the order 

foreach(var u in uavData)
{
    await producer.SendProduceAsync(u, uavTopic);
}
await producer.SendRawAsync("END_UAV", uavTopic);
Console.WriteLine("End Send Uav");
// now next loop (in the will be need to do unsub)
foreach(var h in hostileUnitsData)
{
    await producer.SendProduceAsync(h, hostileUnitsTopic);
}

await producer.SendRawAsync("END_HOSTILES", hostileUnitsTopic);
Console.WriteLine("End Send Hostiles");
//now next loop need to unsub in the consumer

foreach (var t in tracksData)
{
    await producer.SendProduceAsync(t, tracksTopic);
}
Console.WriteLine("End to send tracks");



