using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace simpleProj.Models;

public class Product
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string name { get; set; }
    public string category { get; set; }
    public double price { get; set; }
    public int stock { get; set; }
    public double rating { get; set; }
    public bool isActive { get; set; }
    
    public string createdAt { get; set; }
}