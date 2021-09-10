using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webshop.DataProviders;
using Webshop.Interfaces;
using Webshop.Models;
using Webshop.Services;

namespace Webshop.Controllers
{
    [ApiController]
    [Route("api/test")]
    public class TestController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IProductDataProvider _productDataProvider;

        public TestController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        [Route("product/new")]
        public async Task NewProduct()
        {
            var product = new Product();
            product.Name = "testproduct";
            product.Price = 299;
            product.Category = "Fat";
            await _productService.Create(product);
        }

        [HttpGet]
        [Route("product/del")]
        public async Task DeleteProducts()
        {
            await _productDataProvider.DeleteAll();
        }
 
        
    }
}