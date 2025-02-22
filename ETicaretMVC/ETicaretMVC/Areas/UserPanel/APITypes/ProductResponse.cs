namespace ETicaretMVC.Areas.UserPanel.APITypes
{
    public class ProductResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public short Stock { get; set; }
        public int? CategoryId { get; set; }
        public IFormFile? Picture { get; set; }
        public string PhotoPath { get; set; }
        //public List<Category> CategoryList { get; set; }
    }
}
