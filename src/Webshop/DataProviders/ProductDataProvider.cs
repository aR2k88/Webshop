using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Webshop.Interfaces;
using Webshop.Models;

namespace Webshop.DataProviders
{
    public interface IProductDataProvider
    {
        public Task<Product> Create(Product product);
        public Task<Product> Update(Product product);
        public Task Delete(Product product);
        public Task<Product> Get(Guid productId);
        public Task<List<Product>> GetByCategory(string category);
        public Task<IEnumerable<Product>> GetAllProducts();
        public Task<List<string>> GetProductCategories();
    }
    public class ProductDataProvider : IProductDataProvider
    {
        private readonly IMongoCollection<Product> _collection;

        public ProductDataProvider(IMongoDatabase database)
        {
            _collection = database.GetCollection<Product>("Product");
        }

        public async Task<Product> Create(Product product)
        {
            await _collection.InsertOneAsync(product);
            return product;
        }

        public async Task<List<string>> GetProductCategories()
        {
            var res = await _collection.DistinctAsync(x => x.Category, new BsonDocument());
            return res.ToList();
        }

        public async Task<Product> Update(Product product)
        {
            await _collection.ReplaceOneAsync(x => x._id == product._id, product);
            return product;
        }

        public async Task Delete(Product product)
        {
            await _collection.DeleteOneAsync(x => x._id == product._id);
        }

        public async Task<Product> Get(Guid productId)
        {
            var res = await _collection.FindAsync(x => x._id == productId);
            return res.FirstOrDefault();
        }
        
        public async Task<List<Product>> GetByCategory(string category)
        {
            var res = await _collection.Find(x => x.Category.ToLower() == category.ToLower()).ToListAsync();
            return res;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }
    }
}