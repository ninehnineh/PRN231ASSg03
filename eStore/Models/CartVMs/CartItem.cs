using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eStore.Models.ProductVMs;

namespace eStore.Models.CartVMs
{
    public class CartItem
    {
        public ProductVM Product { get; set; }
        public int Quantity { get; set; }
        public string UserId { get; set; } 
    }
}