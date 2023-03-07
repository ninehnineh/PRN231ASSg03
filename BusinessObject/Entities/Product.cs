using BusinessObject.Entities.Common;

namespace BusinessObject.Entities
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public int Weight { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitslnStock { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}