using Cart.API.Entities;
using Cart.API.Interfaces.IRpositories;
using Cart.API.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cart.API.Services
{
    public class CartService : ICartService
    {
        private ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<IEnumerable<Entities.Cart>> GetAllCartsAsync()
        {
            return await _cartRepository.GetAllAsync();
        }
        public async Task<Entities.Cart> GetCartByIdAsync(int Id)
        {
            return await _cartRepository.GetByIdAsync(Id);
        }
        public async Task<bool> AddCartAsync(Entities.Cart cart)
        {
            return await _cartRepository.AddAsync(cart);
        }
        public async Task<bool> UpdateCartAsync(Entities.Cart cart)
        {
            return await _cartRepository.UpdateAsync(cart);
        }
        public async Task<bool> DeleteCartAsync(int Id)
        {
            return await _cartRepository.DeleteAsync(Id);
        }
    }
}
