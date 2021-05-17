using Cart.API.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cart.API.Interfaces.IUnitOfWork
{
    public interface IUnitOfWork
    {
        public ICartService cartService { get; }
        public ICartItemsService cartItemsService { get; }
    }
}
