using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ProductDTOs
{
    public class ProductListDto : BaseDto
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitslnStock { get; set; }
    }
}
