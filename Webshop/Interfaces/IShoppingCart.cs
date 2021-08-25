using System.Threading.Tasks;
using Webshop.Interfaces.Models;

namespace Webshop.Interfaces
{
    public interface IShoppingCart
    {
        Task<Cart> AddToCart();
        Task<Cart> RemoveFromCart();
        Task<Cart> EmptyCart();
    }
}