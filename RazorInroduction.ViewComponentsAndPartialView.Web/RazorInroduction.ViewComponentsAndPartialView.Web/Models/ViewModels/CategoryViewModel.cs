using System.Collections.Generic;

namespace RazorInroduction.ViewComponentsAndPartialView.Web.Models.ViewModels
{
    public class CategoryViewModel
    {
        public List<Product> Products { get; set; }
        public MenuViewModel MenuViewModel { get; set; }
        public PopularProductViewModel PopularProductViewModel { get; set; }
    }
}
