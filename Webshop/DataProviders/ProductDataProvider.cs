using System.Threading.Tasks;
using MongoDB.Driver;
using Webshop.Interfaces.Models;

namespace Webshop.DataProviders
{
    public class ProductDataProvider
    {
        private readonly IMongoCollection<Product> _collection;

        public ProductDataProvider(IMongoDatabase database)
        {
            _collection = database.GetCollection<Product>("Product");
        }

        public async Task<Product> Create(Product product)
        {
            await _collection.ReplaceOneAsync(x => x.Id == product.Id, product, new ReplaceOptions{IsUpsert = true});
            return product;
        }
        
    }
}