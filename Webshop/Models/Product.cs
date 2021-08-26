using MongoDB.Bson.Serialization.Attributes;

namespace Webshop.Interfaces.Models
{
    public class Product
    {
        [BsonId]
        public string Id { get; set; }
        public string Name { get; set; }
    }
}