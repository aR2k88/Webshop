using System;
using System.Threading.Tasks;
using Webshop.Models;

namespace Webshop.Interfaces
{
    public interface IShoppingCartService
    {
        Task<Cart> AddToCart(Guid cartId, Product product, int amount = 1);
        Task<Cart> RemoveFromCart(Guid cartId, Product product, int amount = 1);
        Task<Cart> EmptyCart(Guid cartId);
    }
}