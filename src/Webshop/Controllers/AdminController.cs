using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Webshop.Controllers
{
    [ApiController]
    [Route("api/admin")]
    public class AdminController : ControllerBase
    {
        [Route("valid")]
        [HttpGet]
        public async Task<bool> ValidUser()
        {
            return true;
        }
    }
}