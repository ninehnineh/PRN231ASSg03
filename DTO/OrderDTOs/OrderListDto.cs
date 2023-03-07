using DTO.OrderDetailDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.OrderDTOs
{
    public class OrderListDto : BaseDto
    {
        public int Freight { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }

        public List<ListOrderDetailDto> OrderDetails { get; set; }
    }
}
