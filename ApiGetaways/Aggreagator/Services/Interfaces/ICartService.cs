using Aggreagator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aggreagator.Services.Interfaces
{
    public interface ICartService
    {
        Task<IEnumerable<CartItemModel>> GetAllCartItems();
        Task<CartItemModel> GetCartItem(int customerId);
        Task<bool> AddCartItem(int customerId, CartItemModel cart);
        Task<bool> UpdateCartItem(int customerId, CartItemModel cart);
        Task<bool> DeleteCartItem(int customerId);
    }
}
