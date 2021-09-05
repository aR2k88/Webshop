using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop.DataProviders;
using Webshop.Interfaces;
using Webshop.Models;

namespace Webshop.Services
{
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

        public Task<Product> Get(Guid productId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var result = await _productDataProvider.GetAllProducts();
            return result.ToList();
        }
        
        
    }
}