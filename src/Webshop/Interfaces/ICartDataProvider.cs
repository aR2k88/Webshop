using System;
using System.Threading.Tasks;
using Webshop.Models;

namespace Webshop.Interfaces
{
    public interface ICartDataProvider
    {
        Task<Cart> Create(Cart cart);
        Task<Cart> Save(Cart cart);
        Task<Cart> Get(Guid cartId);
    }
}