﻿using BusinessObject.Entities.Common;

namespace BusinessObject.Entities
{
    public class OrderDetail
    {
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}