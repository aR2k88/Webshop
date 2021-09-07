using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Webshop.Models
{
    public class ProductUrl
    {
        [BsonId]
        public string Url { get; set; }
        [BsonRepresentation(BsonType.String)]
        public Guid ConnectedProduct { get; set; }

        public ProductUrl(Guid productId, string productName)
        {
            ConnectedProduct = productId;
            Url = productName.Replace(' ', '-');
        }
    }
}