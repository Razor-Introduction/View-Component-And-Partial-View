using RazorInroduction.ViewComponentsAndPartialView.Web.Models.Strategy;
using System.Collections.Generic;

namespace RazorInroduction.ViewComponentsAndPartialView.Web.Models.ViewModels
{
    public class CategoryViewModel
    {
        public List<Product> Products { get; set; }
        public MenuModel MenuModel { get; set; }
        public PopularProductModel PopularProductModel { get; set; }
    }
}
