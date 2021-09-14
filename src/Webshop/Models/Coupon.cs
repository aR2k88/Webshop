using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Webshop.Models
{
    public class Coupon
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid _id { get; set; }
        
    }
}