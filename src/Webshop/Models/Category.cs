using MongoDB.Bson.Serialization.Attributes;

namespace Webshop.Models
{
    public class Category
    {
        [BsonId]
        public string CategoryName { get; set; }
        
    }
}