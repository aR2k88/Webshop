using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Webshop.Interfaces;
using Webshop.Models;

namespace Webshop.DataProviders
{
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

        public Task<Product> Get(Guid productId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllProducts()
        {
            throw new NotImplementedException();
        }
    }
}