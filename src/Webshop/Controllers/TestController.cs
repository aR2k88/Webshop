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
        public TestController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        [Route("product/new")]
        public async Task NewProduct()
        {
            var product1 = new Product();
            product1.Name = "Test Produkt 1";
            product1.Price = 299;
            product1.Category = "Fat";
            product1.Description =
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt " +
                "ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure " +
                "dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
            var product2 = new Product();
            product2.Name = "Test Produkt 2";
            product2.Price = 499;
            product2.Category = "Vase";
            product2.Description =
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt " +
                "ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure " +
                "dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
            var product3 = new Product();
            product3.Name = "Test Produkt 3";
            product3.Price = 349;
            product3.Category = "Fat";
            product3.Description =
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt " +
                "ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure " +
                "dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
            var product4 = new Product();
            product4.Name = "Test Produkt 4";
            product4.Price = 349;
            product4.Category = "Fat";
            product4.Description =
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt " +
                "ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure " +
                "dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
            
            await _productService.Create(product1);
            await _productService.Create(product2);
            await _productService.Create(product3);
            await _productService.Create(product4);
        }

 
        
    }
}