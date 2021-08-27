using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Webshop.Models;

namespace Webshop.Interfaces
{
    public interface IProductDataProvider
    {
        public Task<Product> Create(Product product);
        public Task<Product> Update(Product product);
        public Task<Product> Delete(Product product);
        public Task<Product> Get(Guid productId);
        public Task<IEnumerable<Product>> GetAllProducts();
    }
}