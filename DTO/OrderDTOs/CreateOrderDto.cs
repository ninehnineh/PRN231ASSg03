using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.OrderDTOs
{
    public class CreateOrderDto : BaseDto
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public DateTime RequiredDate { get; set; }

        [Required]
        public DateTime ShippedDate { get; set; }

        [Required]
        public decimal Freight { get; set; }
    }
}
