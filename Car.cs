using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBManager
{
    public class Car
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string? Model { get; set; }
        public string? Engine { get; set; }
        public int displacement { get; set; }
    }
}
