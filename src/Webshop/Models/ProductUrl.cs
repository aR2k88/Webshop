using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Webshop.Models
{
    public class ProductUrl
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string Url { get; set; }
        public Guid ConnectedProduct { get; set; }

        public ProductUrl(Guid productId, string productName)
        {
            ConnectedProduct = productId;
            Url = productName.Replace(' ', '-');
        }
    }
}