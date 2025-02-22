using Infrastructure.Model;

namespace ModelLayer.Entities
{
    public class Product : AuditableEntity<int>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public short? Stock { get; set; }
        public string? PhotoPath { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public byte[]? Picture { get; set; }
        public Category? Category { get; set; }
    }
}
