using Cart.API.Entities;
using Cart.API.Helpers;
using Cart.API.Interfaces.IRpositories;
using Cart.API.Interfaces.IServices;
using Cart.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cart.API.Services
{
    public class CartItemsService : ICartItemsService
    {
        private ICartItemsRepository _cartItemsRepository;

        public CartItemsService(ICartItemsRepository cartItemsRepository)
        {
            _cartItemsRepository = cartItemsRepository;
        }

        public async Task<IEnumerable<CartItems>> GetAllCartItemsAsync()
        {
            return await _cartItemsRepository.GetAllAsync();
        }
        public async Task<PagedList<Item>> GetAllCartItemsForCartAsync(int cartId, CartItemsParameters cartItemParams)
        {
            return await _cartItemsRepository.GetAllCartItemsForCartAsync(cartId, cartItemParams);
        }
        
        public async Task<PagedList<CartItems>> GetAllCartItemsPaginationAsync(CartItemsParameters cartItemParams)
        {
            return await _cartItemsRepository.GetAllItemsPagination(cartItemParams);
        }

        public async Task<CartItems> GetCartItemByIdAsync(int Id)
        {
            return await _cartItemsRepository.GetByIdAsync(Id);
        }
        public async Task<bool> AddCartItemAsync(CartItems cart)
        {
            return await _cartItemsRepository.AddAsync(cart);
        }
        public async Task<bool> UpdateCartItemAsync(CartItems cart)
        {
            return await _cartItemsRepository.UpdateAsync(cart);
        }
        public async Task<bool> DeleteCartItemAsync(int Id)
        {
            return await _cartItemsRepository.DeleteAsync(Id);
        }
    }
}
