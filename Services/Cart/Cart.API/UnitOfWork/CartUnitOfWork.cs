using Cart.API.Interfaces.IRpositories;
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
        private readonly ICartRepository _cartRepository;
        private readonly ICartItemsRepository _cartItemsRepository;
        public CartUnitOfWork(
            ICartRepository cartRepository, 
            ICartItemsRepository cartItemsRepository)
        {
            _cartRepository = cartRepository;
            _cartItemsRepository = cartItemsRepository;
        }
        public ICartRepository cartRepository { get { return _cartRepository; } }

        public ICartItemsRepository cartItemsRepository { get { return _cartItemsRepository; } }
    }
}
