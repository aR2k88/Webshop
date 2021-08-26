using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webshop.DataProviders;
using Webshop.Interfaces.Models;

namespace Webshop.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly ProductDataProvider ProductDataProvider;
        public ProductController(ProductDataProvider productDataProvider)
        {
            ProductDataProvider = productDataProvider;
        }

        [Route("create")]
        public async Task Create()
        {
            var product = new Product();
            product.Name = "Testproduct";
            await ProductDataProvider.Create(product);
        }
    }
}