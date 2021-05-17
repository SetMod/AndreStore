using Cart.API.Entities;
using Cart.API.Interfaces.IConnectionFacory;
using Cart.API.Interfaces.IRpositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cart.API.Repositories
{
    public class CartItemsRepository : GenericRpository<CartItems>, ICartItemsRepository
    {
        public CartItemsRepository(ICartConnectionFactory connectionFactory) :base(connectionFactory, "CartItems")
        {
        }
    }
}
