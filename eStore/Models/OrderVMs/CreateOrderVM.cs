namespace eStore.Models.OrderVMs
{
    public class CreateOrderVM
    {
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public decimal? Freight { get; set; }
    }
}
