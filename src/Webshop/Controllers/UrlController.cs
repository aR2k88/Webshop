using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webshop.Services;

namespace Webshop.Controllers
{
    [ApiController]
    [Route("api/url")]
    public class UrlController : ControllerBase
    {
        private readonly IUrlManagerService _urlManagerService;

        public UrlController(IUrlManagerService urlManagerService)
        {
            _urlManagerService = urlManagerService;
        }

        [HttpGet]
        [Route("{productIdString}")]
        public async Task<string> GetUrlByProductId(string productIdString)
        {
            if (Guid.TryParse(productIdString, out Guid productId))
            {
                return await _urlManagerService.GetUrlByProductId(productId);
            }
            return null;
        }

    }
}