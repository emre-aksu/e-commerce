using Infrastructure.Model;

namespace ModelLayer.Entities
{
    public class Category: AuditableEntity<int>
    {
        public Category()
        {
            Products = new List<Product>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public byte[]? Picture { get; set; }
        public string? PhotoPath { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
