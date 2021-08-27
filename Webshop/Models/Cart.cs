using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Webshop.Models
{
    public class Cart
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid _id { get; set; }
        public List<CartItem> CartItems { get; set; }

        public Cart()
        {
            CartItems = new List<CartItem>();
        }
    }
}