using Cart.API.Entities;
using Cart.API.Interfaces.IConnectionFacory;
using Cart.API.Interfaces.IRpositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cart.API.Repositories
{
    public class CartRepository : GenericRpository<Entities.Cart>, ICartRepository
    {
        public CartRepository(ICartConnectionFactory connectionFactory) : base(connectionFactory, "Cart")
        {
        }
    }
}
