namespace ETicaretMVC.Areas.AdminPanel.APITypes
{
    public class ProductPostRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public short Stock { get; set; }
        public int CategoryId { get; set; }
        public string PhotoPath { get; set; }

        // Birden fazla fotoğraf yüklemek için liste
        //public IFormFileCollection Photos { get; set; }
    }
}
