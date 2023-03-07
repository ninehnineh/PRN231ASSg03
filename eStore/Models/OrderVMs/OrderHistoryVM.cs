using eStore.Models.OrderDetailVMs;

namespace eStore.Models.OrderVMs
{
    public class OrderHistoryVM
    {
        public int Freight { get; set; }
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        public List<OrderDetailVM> OrderDetails { get; set; }

    }
}
