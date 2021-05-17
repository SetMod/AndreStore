using Customer.API.EfDbContext;
using Customer.API.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.API.Repositories
{
    public class CustomerRepository : GenericRepository<Entities.Customer>, ICustomerRepository
    {
        public CustomerRepository(CustomerDbContext context):base(context)
        {
        }
    }
}
