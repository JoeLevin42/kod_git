using AnalyzeProducer.Models;
using AnalyzeProducer.Services;
using Microsoft.Extensions.Configuration;



var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();


string analystsPath = Path.Combine(AppContext.BaseDirectory, "Data", "analysts.json");
string callsPath = Path.Combine(AppContext.BaseDirectory, "Data", "calls.json");


var bootstrapServers = configuration["Kafka:BootstrapServers"] ?? "localhost:9092";

var analystTopic = configuration["Kafka:Topics:Analysts"] ?? "Analysts";
var callsTopic = configuration["Kafka:Topics:Calls"] ?? "Calls";

var producer = new KafkaProducer(bootstrapServers);
var jsonLoader = new LoaderDataJson();

var analystsData = jsonLoader.LoadFromJson<Analysts>(analystsPath);
var callsData = jsonLoader.LoadFromJson< Calls>(callsPath);

foreach (var a in analystsData)
{
    await producer.ProduceSendAsync<Analysts>(a, analystTopic);
}
await producer.ProduceRawStringAsync("END_ANALYSTS", analystTopic);

foreach (var c in callsData)
{
    await producer.ProduceSendAsync<Calls>(c, callsTopic);
}
producer.Dispose();