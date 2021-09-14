using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webshop.Interfaces;
using Webshop.Models;

namespace Webshop.Controllers
{
    [ApiController]
    [Route("api/cart")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        [Route("{cartIdString}")]
        public async Task<Cart> GetCart(string cartIdString)
        {
            return await _cartService.Get(cartIdString);
        }

        [HttpPost]
        [Route("add")]
        public async Task<Cart> AddToCart([FromBody]NewCartItem newCartitem)
        {
            return await _cartService.AddToCart(newCartitem.CartId, newCartitem.Product);
        }

        [HttpPost]
        [Route("remove")]
        public async Task<Cart> RemoveFromCart([FromBody] NewCartItem cartItem)
        {
            return await _cartService.RemoveFromCart(cartItem.CartId, cartItem.Product);
        }

        public class NewCartItem
        {
            public Guid CartId { get; set; }
            public Product Product { get; set; }
        }


    }
}