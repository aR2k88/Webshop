using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using Webshop.Models;

namespace Webshop.DataProviders
{
    public interface IProductUrlDataProvider
    {
        public Task<ProductUrl> Create(ProductUrl productUrl);
        public Task<ProductUrl> Update(ProductUrl productUrl);
        public Task<ProductUrl> Delete(ProductUrl productUrl);
        public Task<ProductUrl> GetByProduct(Guid productId);
        public Task<Guid> GetProductIdByProductUrl(string productUrl);
        public Task<IEnumerable<ProductUrl>> GetAllUrls();
    }

    public class ProductUrlDataProvider : IProductUrlDataProvider
    {
        private readonly IMongoCollection<ProductUrl> _collection;
        
        public ProductUrlDataProvider(IMongoDatabase database)
        {
            _collection = database.GetCollection<ProductUrl>("ProductUrl");
        }
        public async Task<ProductUrl> Create(ProductUrl productUrl)
        {
            var existing = await GetByUrl(productUrl.Url);
            if (existing == null)
            {
                await _collection.InsertOneAsync(productUrl);
            }
            else
            {
                var newUrl = await GenerateUniqueName(productUrl.Url);
                productUrl.Url = newUrl;
                await _collection.InsertOneAsync(productUrl);
            }
            return productUrl;
        }

        public Task<ProductUrl> Update(ProductUrl productUrl)
        {
            throw new NotImplementedException();
        }

        public Task<ProductUrl> Delete(ProductUrl productUrl)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductUrl> GetByProduct(Guid productId)
        {
            return await _collection.Find(x => x.ConnectedProduct == productId).SingleOrDefaultAsync();
        }

        public async Task<Guid> GetProductIdByProductUrl(string productUrl)
        {
            var res = await _collection.FindAsync(x => x.Url == productUrl);
            var result = await res.SingleOrDefaultAsync();
            return result.ConnectedProduct;
        }

        public async Task<ProductUrl> GetByUrl(string url)
        {
            var res = await _collection.FindAsync(x => x.Url == url);
            return res.FirstOrDefault();
        }

        public async Task<IEnumerable<ProductUrl>> GetAllUrls()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        private async Task<string> GenerateUniqueName(string url)
        {
            var data = await GetAllUrls();
            var allMatchingUrls = data.ToList().Where(x => x.Url.StartsWith(url));
            return url + "-" + (allMatchingUrls.Count() + 1);
        }
    }
}