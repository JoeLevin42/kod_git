
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace csharpQuickstart.Models;

public class Product
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public int? Id { get; set; }
    public string Name { get; set; }

    public string Category { get; set; }

    public double Price { get; set; }
    public int Stock { get; set; }
    public double Rating { get; set; }
    public bool IsActive{ get; set; }
    public  DateTime CreatedAt { get; set; }
    
}