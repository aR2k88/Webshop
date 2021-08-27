using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop.Interfaces;
using Webshop.Models;

namespace Webshop.Services
{
    public class CartService : ICartService
    {
        private readonly ICartDataProvider _cartDataProvider;

        public CartService(ICartDataProvider cartDataProvider)
        {
            _cartDataProvider = cartDataProvider;
        }

        public async Task<Cart> AddToCart(Guid cartId, Product product, int amount = 1)
        {
            Cart cart;
            if (cartId == default)
            {
                cart = new Cart();
                cart = await _cartDataProvider.Create(cart);
            }
            else
            {
                cart = await _cartDataProvider.Get(cartId);
            }

            var existingItem = cart.CartItems.SingleOrDefault(x => x.Product._id == product._id);
            if (existingItem == null)
            {
                cart.CartItems.Add(new CartItem(product, amount));
            }
            else
            {
                cart.CartItems.Remove(existingItem);
                existingItem.Number += amount;
                cart.CartItems.Add(existingItem);
            }
            
            return await _cartDataProvider.Save(cart);
        }

        public async Task<Cart> RemoveFromCart(Guid cartId, Product product, int amount = 1)
        {
            var cart = await _cartDataProvider.Get(cartId);
            var existingItem = cart.CartItems.SingleOrDefault(x => x.Product._id == product._id);
            if (existingItem == null) return cart;
            cart.CartItems.Remove(existingItem);
            existingItem.Number -= 1;
            if (existingItem.Number < 0) existingItem.Number = 0;
            cart.CartItems.Add(existingItem);
            return await _cartDataProvider.Save(cart);
        }

        public async Task<Cart> EmptyCart(Guid cartId)
        {
            var cart = await _cartDataProvider.Get(cartId);
            cart.CartItems = new List<CartItem>();
            return await _cartDataProvider.Save(cart);
        }
    }
}