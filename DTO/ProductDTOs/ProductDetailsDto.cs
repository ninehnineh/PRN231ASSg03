using BusinessObject.Entities;
using DTO.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ProductDTOs
{
    public class ProductDetailsDto : BaseDto
    {
        public string ProductName { get; set; }
        public int Weight { get; set; }
        public string CategoryName { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitslnStock { get; set; }
        public CategoryDto Category { get; set; }
    }
}
