using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cart.API.Entities
{
    public class CartCheckout
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public int Amount { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
