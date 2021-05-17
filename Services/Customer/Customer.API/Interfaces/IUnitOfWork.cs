using Customer.API.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.API.Interfaces
{
    public interface IUnitOfWork
    {
        public ICustomerRepository customerRepository { get; }
    }
}
