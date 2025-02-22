using ModelLayer.Entities;

namespace ETicaretMVC.Areas.UserPanel.Models.ViewModels
{
    public class ProductListViewModel
    {
        public List<Product> ProductList { get; set; }
        public List<Category> CategoryList { get; set; }
    }
}
