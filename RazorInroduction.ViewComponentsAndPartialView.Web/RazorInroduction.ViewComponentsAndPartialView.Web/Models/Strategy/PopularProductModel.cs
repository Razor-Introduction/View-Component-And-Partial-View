using RazorInroduction.ViewComponentsAndPartialView.Web.Models.ViewModels;

namespace RazorInroduction.ViewComponentsAndPartialView.Web.Models.Strategy
{
    public class PopularProductModel
    {
        public string? Category { get; set; }
        public int Count { get; set; }
        public PopularProductViewModel PopularProductViewModel { get; set; }
    }
}
