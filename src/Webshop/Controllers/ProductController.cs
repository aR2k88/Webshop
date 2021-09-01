using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webshop.Interfaces;
using Webshop.Models;

namespace Webshop.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<List<Product>> GetAllProducts()
        {
            var result =  await _productService.GetAllProducts();
            return result;
        }
        [HttpPost]
        [Route("create")]
        public async Task Create(Product product)
        {
            await _productService.Create(product);
        }
        [HttpGet]
        [Route("testnew")]
        public async Task Testnew()
        {
            var product = new Product();
            product.Name = "testproduct";
            product.Price = 299;
            await _productService.Create(product);
        }

        [HttpGet]
        [Route("Test")]
        public async Task<string> Test()
        {
            return "WOHOO";
        }
        
    }
}