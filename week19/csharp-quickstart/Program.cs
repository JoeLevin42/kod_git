using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using System.Reflection.Metadata;

// Sets the connection URI
const string connectionUri = "mongodb://localhost:27017";

// Creates a new client and connects to the server
var client = new MongoClient(connectionUri);

var collection = client.GetDatabase("store").GetCollection<BsonDocument>("products");
var filter = Builders<BsonDocument>.Filter.Empty;
var document = collection.Find(filter).ToListAsync();
Console.WriteLine(document.ToJson(new JsonWriterSettings { Indent = true }));
{

}