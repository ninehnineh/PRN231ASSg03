using DTO.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.OrderDetailDTOs
{
    public class ListOrderDetailDto
    {
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public int ProductId { get; set; }
        public ProductDetailsDto Product { get; set; }

    }
}
