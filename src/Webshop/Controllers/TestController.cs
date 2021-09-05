using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        private readonly ICategoryService _categoryService;
        public TestController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        [HttpGet]
        [Route("product/testnew")]
        public async Task NewProduct()
        {
            var product = new Product();
            product.Name = "testproduct";
            product.Price = 299;
            product.Category = "Fat";
            await _productService.Create(product);
        }
        [HttpGet]
        [Route("category/testnew")]
        public async Task NewCategory()
        {
            var categoryString = "Fat";
            await _categoryService.CreateCategory(categoryString);
        }
        
    }
}