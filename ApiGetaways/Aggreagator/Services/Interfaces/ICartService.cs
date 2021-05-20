using Aggregator.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aggregator.API.Services.Interfaces
{
    public interface ICartService
    {
        Task<IEnumerable<ItemsModel>> GetAllCartItems(int cartId);
        Task<CartItemModel> GetCartItem(int customerId, int cartItemId);
        Task<CartModel> GetCart(int customerId);
        Task<bool> AddCartItem(int customerId, CartItemModel cart);
        Task<bool> UpdateCartItem(int customerId, CartItemModel cart);
        Task<bool> DeleteCartItem(int customerId);
    }
}
