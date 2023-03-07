using eStore.Models.ProductVMs;

namespace eStore.Models.OrderDetailVMs
{
    public class OrderDetailVM
    {
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public int ProductId { get; set; }
        public ProductVM Product { get; set; }
    }
}
