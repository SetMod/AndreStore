using Ordering.BLL.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.BLL.Interfaces.IUnitOfWork
{
    public interface IOrderingUnitOfWork
    {
        IOrderingService orderService { get; }
    }
}
