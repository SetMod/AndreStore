using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aggreagator.Models
{
    public class CartModel
    {
        public int Id { get; set; }
        public int TotalPrice { get; set; }
        public int CustomerId { get; set; }
    }
}
