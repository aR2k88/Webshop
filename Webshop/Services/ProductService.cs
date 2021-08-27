using System;
using System.Collections.Generic;
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

        public Task<Product> Create(Product product)
        {
            throw new NotImplementedException();
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

        public Task<IEnumerable<Product>> GetAllProducts()
        {
            throw new NotImplementedException();
        }
    }
}