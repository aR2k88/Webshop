using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop.DataProviders;
using Webshop.Interfaces;
using Webshop.Models;

namespace Webshop.Services
{
    public interface IProductService
    {
        public Task<Product> Create(Product product);
        public Task<Product> Save(Product product);
        public Task<Product> Delete(Product product);
        public Task<Product> Get(Guid productId);
        public Task<Product> GetByProductUrl(string category, string productUrl);
        public Task<List<Product>> GetByCategory(string category);
        public Task<List<Product>> GetAllProducts();
        public Task<List<string>> GetAllCategories();
    }
    public class ProductService : IProductService
    {
        private readonly IProductDataProvider _productDataProvider;
        private readonly IUrlManagerService _urlManagerService;

        public ProductService(IProductDataProvider productDataProvider, IUrlManagerService urlManagerService)
        {
            _productDataProvider = productDataProvider;
            _urlManagerService = urlManagerService;
        }

        public async Task<Product> Create(Product product)
        {
            var newProduct = await _productDataProvider.Create(product);
            await _urlManagerService.GenerateUrlForNewProduct(newProduct);
            return newProduct;
        }

        public Task<Product> Save(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Product> Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> Get(Guid productId) => await _productDataProvider.Get(productId);
        public async Task<Product> GetByProductUrl(string category, string productUrl)
        {
            var gettingProductsInCategory = _productDataProvider.GetByCategory(category);
            var productId = await _urlManagerService.GetProductIdFromProductUrl(productUrl);
            var categoryProducts = await gettingProductsInCategory;
            return categoryProducts != null ? categoryProducts.FirstOrDefault(x => x._id == productId) : null;
        }

        public async Task<List<Product>> GetByCategory(string category) => await _productDataProvider.GetByCategory(category);

        public async Task<List<Product>> GetAllProducts()
        {
            var result = await _productDataProvider.GetAllProducts();
            return result.ToList();
        }

        public async Task<List<string>> GetAllCategories()
        {
            var result = await _productDataProvider.GetAllCategories();
            return result;
        }
        
        
    }
}