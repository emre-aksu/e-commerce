using Infrastructure.Model;
using Microsoft.AspNetCore.Http;

namespace ModelLayer.Dtos
{
    public class CategoryEditDto: IDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile Photo { get; set; }

        public int ProductId { get; set; } // hata alırsam bunu sil product ile alakalı
    }
}
