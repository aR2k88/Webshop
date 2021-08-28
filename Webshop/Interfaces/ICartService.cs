using System;
using System.Threading.Tasks;
using Webshop.Models;

namespace Webshop.Interfaces
{
    public interface ICartService
    {
        Task<Cart> Get(Guid cartId);
        Task<Cart> AddToCart(Guid cartId, Product product, int amount = 1);
        Task<Cart> RemoveFromCart(Guid cartId, Product product, int amount = 1);
        Task<Cart> EmptyCart(Guid cartId);
    }
}