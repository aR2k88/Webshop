using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Webshop.Models;

namespace Webshop.Interfaces
{
    public interface IProductService
    {
        public Task<Product> Create(Product product);
        public Task<Product> Save(Product product);
        public Task<Product> Delete(Product product);
        public Task<Product> Get(Guid productId);
        public Task<IEnumerable<Product>> GetAllProducts();
    }
}