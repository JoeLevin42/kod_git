using AnalyzeConsumer.Data;
using AnalyzeConsumer.Models;
using Confluent.Kafka;
using System.Text.Json;
namespace AnalyzeConsumer.Services;

public class EventProcessingService
{
    private readonly ApplicationDbContext _db;

    public EventProcessingService(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<bool> ProcessAnalysts(string jsonMessage)
    {
        var jsonObj = JsonSerializer.Deserialize<Analysts>(jsonMessage);

        if (jsonObj == null)
        {
            return false;
        }

        _db.Analysts.Add(jsonObj);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ProcessCalls(string jsonMessage)
    {
        var jsonObj = JsonSerializer.Deserialize<Calls>(jsonMessage);

        if (jsonObj == null)
        {
            return false;
        }

        _db.Calls.Add(jsonObj);
        await _db.SaveChangesAsync();
        return true;
    }
}