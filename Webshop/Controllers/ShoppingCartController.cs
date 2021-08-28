using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webshop.Interfaces;
using Webshop.Models;

namespace Webshop.Controllers
{
    [ApiController]
    [Route("api/cart")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public ShoppingCartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public async Task<Cart> GetCart(Guid cartId)
        {
            return await _cartService.Get(cartId);
        }

        [HttpPost]
        [Route("add/{cartId}")]
        public async Task<Cart> AddToCart(Guid cartId, [FromBody]Product product)
        {
            return await _cartService.AddToCart(cartId, product);
        }

        [HttpPost]
        [Route("remove/{cartId")]
        public async Task<Cart> RemoveFromCart(Guid cartId, [FromBody] Product product)
        {
            return await _cartService.RemoveFromCart(cartId, product);
        }
            
        


    }
}