using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Webshop.Controllers
{
    [ApiController]
    [Route("api/admin")]
    public class AdminController : ControllerBase
    {
        [HttpGet]
        public async Task<int> TestEndpoint()
        {
            var testValue = Request.Cookies["token"];
            var test = 1223;
            return test;
        }
    }
}