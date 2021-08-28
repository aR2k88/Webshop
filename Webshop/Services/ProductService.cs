using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop.Interfaces;
using Webshop.Models;

namespace Webshop.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductDataProvider _productDataProvider;

        public ProductService(IProductDataProvider productDataProvider)
        {
            _productDataProvider = productDataProvider;
        }

        public Task<Product> Create(Product product) => _productDataProvider.Create(product);

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