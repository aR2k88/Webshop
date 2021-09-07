using System;
using System.Threading.Tasks;
using Webshop.DataProviders;
using Webshop.Models;

namespace Webshop.Services
{
    public interface IUrlManagerService
    {
        Task<ProductUrl> GenerateUrlForNewProduct(Product product);
        Task<Guid> GetProductIdFromProductUrl(string productUrl);
    }
    public class UrlManagerService : IUrlManagerService
    {
        private readonly IProductUrlDataProvider _productUrlDataProvider;
        public UrlManagerService(IProductUrlDataProvider productUrlDataProvider)
        {
            _productUrlDataProvider = productUrlDataProvider;
        }
        public async Task<ProductUrl> GenerateUrlForNewProduct(Product product)
        {
            var newProductUrl = new ProductUrl(product._id, product.Name);
            var result = await _productUrlDataProvider.Create(newProductUrl);
            return result;
        }

        public async Task<Guid> GetProductIdFromProductUrl(string productUrl)
        {
            var res = await _productUrlDataProvider.GetProductIdByProductUrl(productUrl);
            return res;
        }
    }
}