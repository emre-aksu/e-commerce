﻿namespace ETicaretMVC.Areas.AdminPanel.APITypes
{
    public class CategoryResponse
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProductCount { get; set; }
        //ProductList bi dursun
        public string PhotoPath { get; set; }
    }
}
