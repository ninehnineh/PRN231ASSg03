using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ProductDTOs
{
    public class UpdateProductQuantityDto : BaseDto
    {
        [Required]
        public int UnitslnStock { get; set; }
    }
}
