using eStore.Models.CategoryVMs;

namespace eStore.Models.ProductVMs
{
    public class ProductDetailsVM
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Weight { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitslnStock { get; set; }

        public int CategoryId { get; set; }
        public CategoryVM Category { get; set; }
    }
}
