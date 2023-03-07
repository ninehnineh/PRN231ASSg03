using BusinessObject.Entities.Common;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Entities
{
    public class Order : BaseEntity
    {

        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public int Freight { get; set; }

        public string AspNetUsersId { get; set; }
        public AspNetUsers AspNetUsers { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
