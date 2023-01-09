using System.Collections.Generic;

namespace RazorInroduction.ViewComponentsAndPartialView.Web.Models.ViewModels
{
    public class PopularProductViewModel
    {
        public List<Product>? Products { get; set; }
        public BaseColor? Color { get; set; }
    }
}
