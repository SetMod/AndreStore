using Aggregator.API.Models;
using Aggregator.API.Services.Interfaces;
using Aggregator.API.Extensions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Aggreagator.API.Services
{
    public class CartService : ICartService
    {
        private readonly HttpClient _client;

        public CartService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<ItemsModel>> GetAllCartItems(int cartId)
        {
            var response = await _client.GetAsync($"/CartItems/cartId={cartId}");
            return await response.ReadContentAs<IEnumerable<ItemsModel>>();
        }

        public async Task<CartModel> GetCart(int customerId)
        {
            var response = await _client.GetAsync($"/Cart/customerId={customerId}");
            return await response.ReadContentAs<CartModel>();
        }

        public async Task<CartItemModel> GetCartItem(int customerId, int cartItemId)
        {
            var response = await _client.GetAsync($"/Cart/{customerId}");
            return await response.ReadContentAs<CartItemModel>();
        }

        public async Task<bool> AddCartItem(int customerId, CartItemModel cart)
        {
            var response = await _client.GetAsync($"/Cart/{customerId}");
            return await response.ReadContentAs<bool>();
        }

        public async Task<bool> UpdateCartItem(int customerId, CartItemModel cartItem)
        {
            var response = await _client.GetAsync($"/Cart/{customerId}");
            return await response.ReadContentAs<bool>();
        }

        public async Task<bool> DeleteCartItem(int customerId)
        {
            var response = await _client.GetAsync($"/Cart/{customerId}");
            return await response.ReadContentAs<bool>();
        }

    }
}
