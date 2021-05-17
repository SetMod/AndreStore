using Cart.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cart.API.Interfaces.IServices
{
    public interface ICartItemsService
    {
        public Task<IEnumerable<CartItems>> GetAllCartItemsAsync();
        public Task<CartItems> GetCartItemByIdAsync(int Id);
        public Task<bool> AddCartItemAsync(CartItems cart);
        public Task<bool> UpdateCartItemAsync(CartItems cart);
        public Task<bool> DeleteCartItemAsync(int Id);
    }
}
