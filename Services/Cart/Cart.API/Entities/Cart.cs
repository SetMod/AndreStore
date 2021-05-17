using Cart.API.Interfaces.IEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cart.API.Entities
{
    public class Cart : IEntity
    {
        public int Id { get; set; }
        public int TotalPrice { get; set; }
        public int CustomerId { get; set; }
    }
}
