using Cart.API.Interfaces.IRpositories;

namespace Cart.API.Interfaces.IUnitOfWork
{
    public interface IUnitOfWork
    {
        public ICartRepository cartRepository { get; }
        public ICartItemsRepository cartItemsRepository { get; }
    }
}
