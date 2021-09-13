using System;
using System.Collections.Generic;
using System.Linq;
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
        public Task<Product> GetByUrl(string url);
        public Task<List<Product>> GetByCategory(string category);
        public Task<List<Product>> GetAllProducts();
        public Task<List<string>> GetAllCategories();
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
            product.Url = await GenerateUniqueName(product.Name);
            await _collection.InsertOneAsync(product);
            return product;
        }

        public async Task<List<string>> GetAllCategories()
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

        public async Task<Product> GetByUrl(string url)
        {
            var res = await _collection.FindAsync(x => x.Url == url);
            return res.FirstOrDefault();
        }
        
        public async Task<List<Product>> GetByCategory(string category)
        {
            var res = await _collection.Find(x => x.Category.ToLower() == category.ToLower()).ToListAsync();
            return res;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var res = await _collection.FindAsync(_ => true);
            return res.ToList();
        }
        private async Task<string> GenerateUniqueName(string productName)
        {
            var name = productName.Replace(' ', '-').ToLower();
            var data = await GetAllProducts();
            var allMatchingUrls = data.Where(x => x.Url.StartsWith(name));
            if (!allMatchingUrls.Any()) return name;
            return name + "-" + (allMatchingUrls.Count() + 1);
        }
    }
}