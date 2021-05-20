using Cart.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cart.API.Interfaces.IServices
{
    public interface ICartService
    {
        public  Task<IEnumerable<Entities.Cart>> GetAllCartsAsync();
        public Task<Entities.Cart> GetCartByIdAsync(int Id);
        public Task<Entities.Cart> GetCartByCustomerIdAsync(int customerId);
        public Task<bool> AddCartAsync(Entities.Cart cart);
        public Task<bool> UpdateCartAsync(Entities.Cart cart);
        public Task<bool> DeleteCartAsync(int Id);
    }
}
