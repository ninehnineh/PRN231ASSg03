using System.ComponentModel.DataAnnotations;

namespace eStore.Models.OrderDetailVMs
{
    public class CreateOrderDetailVM
    {
        [Required]
        public int OrderId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public int Quantity { get; set; }

        public double Discount { get; set; }
    }
}
