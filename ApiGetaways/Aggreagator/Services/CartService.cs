using Aggreagator.Models;
using Aggreagator.Extensions;
using Aggreagator.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Aggreagator.Services
{
    public class CartService : ICartService
    {
        private readonly HttpClient _client;

        public CartService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public Task<bool> AddCartItem(int customerId, CartItemModel cart)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCartItem(int customerId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CartItemModel>> GetAllCartItems()
        {
            throw new NotImplementedException();
        }

        public async Task<CartModel> GetCart(int customerId)
        {
            var response = await _client.GetAsync($"/Cart/{customerId}");
            var responseItems = await _client.GetAsync($"/CartItems");
            return await response.ReadContentAs<CartModel>();
        }

        public Task<CartItemModel> GetCartItem(int customerId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCartItem(int customerId, CartItemModel cart)
        {
            throw new NotImplementedException();
        }
    }
}
