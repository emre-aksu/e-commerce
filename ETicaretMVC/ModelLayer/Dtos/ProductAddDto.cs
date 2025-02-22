using Infrastructure.Model;
using Microsoft.AspNetCore.Http;

namespace ModelLayer.Dtos
{
    public class ProductAddDto : IDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public short Stock { get; set; }
        public int CategoryId { get; set; }

        //public string PhotoPath {  get; set; }  
        public IFormFile Photo { get; set; }
    }
}
