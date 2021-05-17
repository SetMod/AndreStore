using Cart.API.Interfaces.IEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cart.API.Interfaces.IRpositories
{
    public interface ICartRepository : IGenericRepository<Cart.API.Entities.Cart>
    {
    }
}
