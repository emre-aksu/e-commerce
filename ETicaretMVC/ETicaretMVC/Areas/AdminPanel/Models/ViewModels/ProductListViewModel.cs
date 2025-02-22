using ModelLayer.Entities;

namespace ETicaretMVC.Areas.AdminPanel.Models.ViewModels
{
    public class ProductListViewModel
    {
        public List<Product> ProductList { get; set; }
        public List<Category> CategoryList { get; set; }
    }
}
