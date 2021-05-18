using Cart.API.Entities;
using Cart.API.Helpers;
using Cart.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cart.API.Interfaces.IServices
{
    public interface ICartItemsService
    {
        public Task<IEnumerable<CartItems>> GetAllCartItemsAsync();
        public Task<PagedList<CartItems>> GetAllCartItemsPaginationAsync(CartItemsParameters cartItemParams);
        public Task<CartItems> GetCartItemByIdAsync(int Id);
        public Task<bool> AddCartItemAsync(CartItems cart);
        public Task<bool> UpdateCartItemAsync(CartItems cart);
        public Task<bool> DeleteCartItemAsync(int Id);
    }
}
