using Cart.API.Entities;
using Cart.API.Helpers;
using Cart.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cart.API.Interfaces.IRpositories
{
    public interface ICartItemsRepository : IGenericRepository<CartItems>
    {
        Task<PagedList<CartItems>> GetAllItemsPagination(CartItemsParameters cartItemParams);
        Task<PagedList<Item>> GetAllCartItemsForCartAsync(int cartId, CartItemsParameters cartItemParams);
    }
}
