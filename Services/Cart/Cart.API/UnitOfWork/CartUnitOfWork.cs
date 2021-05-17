using Cart.API.Interfaces.IServices;
using Cart.API.Interfaces.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cart.API.UnitOfWork
{
    public class CartUnitOfWork : IUnitOfWork
    {
        private readonly ICartService _cartService;
        private readonly ICartItemsService _cartItemsService;
        public CartUnitOfWork(
            ICartService cartService, 
            ICartItemsService cartItemsService)
        {
            _cartService = cartService;
            _cartItemsService = cartItemsService;
        }
        public ICartService cartService { get { return _cartService; } }

        public ICartItemsService cartItemsService { get { return _cartItemsService; } }
    }
}
