using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Webshop.Interfaces;
using Webshop.Models;

namespace Webshop.DataProviders
{
    public interface IProductDataProvider
    {
        public Task<Product> Create(Product product);
        public Task<Product> Update(Product product);
        public Task<Product> Delete(Product product);
        public Task<Product> Get(Guid productId);
        public Task<IEnumerable<Product>> GetAllProducts();
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

        public Task<Product> Update(Product product)
        {
            throw new System.NotImplementedException();
        }

        public Task<Product> Delete(Product product)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Product> Get(Guid productId)
        {
            var res = await _collection.FindAsync(x => x._id == productId);
            return res.FirstOrDefault();
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }
    }
}