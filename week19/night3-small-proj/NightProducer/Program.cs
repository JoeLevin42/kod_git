using NightProducer.Services;
using NightProducer.Models;
using Microsoft.Extensions.Configuration;


var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json").Build();

var analystsPath = Path.Combine(AppContext.BaseDirectory, "Data", "analysts.json");
var callsPath = Path.Combine(AppContext.BaseDirectory, "Data", "calls.json");

var bootstrapServers = configuration["Kafka:BootstrapServers"] ?? "localhost:9092";
var analystsTopic = configuration["Kafka:Topics:Analysts"] ?? "Analysts";
var callsTopic = configuration["Kafka:Topics:Calls"] ?? "Calls";
// until here this is the basic configuration

var producer = new ProducerService(bootstrapServers);
var jsonLoader = new JsonLoaderService();

var analystsData = jsonLoader.LoadFromJson<Analysts>(analystsPath);
var callsData = jsonLoader.LoadFromJson<Calls>(callsPath);

foreach (var a in analystsData)
{
    await producer.SendAsync(a, analystsTopic);
}

await producer.SendRawMsg("END-ANALYSTS", analystsTopic);
//need to send end msg

foreach (var c in callsData)
{
    await producer.SendAsync(c, callsTopic);
}

producer.Dispose();