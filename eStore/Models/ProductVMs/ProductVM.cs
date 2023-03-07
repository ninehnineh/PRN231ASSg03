using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eStore.Models.ProductVMs
{
    public class ProductVM
    {
        public string ProductName { get; set; }
        public int Weight { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitslnStock { get; set; }
        public int id { get; set; }
    }
}