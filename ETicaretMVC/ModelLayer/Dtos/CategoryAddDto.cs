using Infrastructure.Model;
using Microsoft.AspNetCore.Http;

namespace ModelLayer.Dtos
{
    public class CategoryAddDto:IDto    
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile Photo { get; set; }

    }
}
