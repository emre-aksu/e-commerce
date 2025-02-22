using ModelLayer.Entities;

namespace ETicaretMVC.Areas.AdminPanel.Models.ViewModels
{
    public class ProductAddViewModel
    {
        public List<Category> CategoryList { get; set; }
        public List<Product> ProductList { get; set; }
    }
}
