using DTO.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CartDTOs
    {
        public ProductDetailsDto Product { get; set; }
        public int Quantity { get; set; }
    }
}
