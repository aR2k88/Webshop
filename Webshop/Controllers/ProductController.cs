﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webshop.DataProviders;
using Webshop.Models;

namespace Webshop.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly ProductDataProvider _productDataProvider;
        public ProductController(ProductDataProvider productDataProvider)
        {
            _productDataProvider = productDataProvider;
        }

        [Route("create")]
        public async Task Create(Product product)
        {
            await _productDataProvider.Create(product);
        }
    }
}