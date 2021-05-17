using Customer.API.Interfaces;
using Customer.API.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.API.CustomerUnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ICustomerRepository _customerRepository;

        public UnitOfWork(ICustomerRepository deliveryRepository)
        {
            _customerRepository = deliveryRepository;
        }
        public ICustomerRepository customerRepository { get { return _customerRepository; } }
    }
}
