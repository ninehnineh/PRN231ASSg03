using BusinessObject.Entities.Common;

namespace BusinessObject.Entities
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }

        public List<Product> Products { get; set; }

    }
}