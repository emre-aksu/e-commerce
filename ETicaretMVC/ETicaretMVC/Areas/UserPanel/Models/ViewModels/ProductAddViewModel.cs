using ModelLayer.Entities;

namespace ETicaretMVC.Areas.UserPanel.Models.ViewModels
{
    public class ProductAddViewModel
    {
        public List<Category> CategoryList { get; set; }
        public List<Product> ProductList { get; set; }
    }
}
