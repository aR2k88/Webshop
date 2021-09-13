using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webshop.Models;
using Webshop.Services;

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

        [HttpGet]
        [Route("{productId}")]
        public async Task<Product> GetProductById(Guid productId)
        {
            var result = await _productService.Get(productId);
            return result;
        }

        [HttpGet]
        [Route("url/{productUrl}")]
        public async Task<Product> GetByProductUrl(string productUrl)
        {
            var result = await _productService.GetByProductUrl(productUrl);
            return result;
        }
        [HttpGet]
        [Route("category/{category}")]
        public async Task<List<Product>> GetProductsByCategory(string category)
        {
            var result = await _productService.GetByCategory(category);
            return result;
        }

        [HttpGet]
        [Route("categories")]
        public async Task<List<string>> GetAllCategories()
        {
           return await _productService.GetAllCategories();
        }
    }
}