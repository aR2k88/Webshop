using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Webshop.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid _id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }
    }
}