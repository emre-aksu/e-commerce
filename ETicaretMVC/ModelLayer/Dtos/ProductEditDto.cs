using Infrastructure.Model;
using Microsoft.AspNetCore.Http;

namespace ModelLayer.Dtos
{
    public class ProductEditDto :IDto
    {
        public int Id { get; set; } //çalışmazsa burası kontrol edilecek
        public string Name { get; set; }
        public decimal Price { get; set; }
        public short Stock { get; set; }
        public string Description { get; set; }
        public string PhotoPath { get; set; }
        public IFormFile Photo { get; set; }
        public int? CategoryId { get; set; }
    }
}
