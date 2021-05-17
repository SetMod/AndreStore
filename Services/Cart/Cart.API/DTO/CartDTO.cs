using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cart.API.DTO
{
    public class CartDTO
    {
        public int Id { get; set; }
        public int TotalPrice { get; set; }
        public int CustomerId { get; set; }
    }
}
