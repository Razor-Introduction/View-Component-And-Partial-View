using Microsoft.AspNetCore.Mvc;
using RazorInroduction.ViewComponentsAndPartialView.Web.Models.Strategy;
using RazorInroduction.ViewComponentsAndPartialView.Web.Models.ViewModels;
using System.Threading.Tasks;

namespace Razor.Inroduction.ViewComponentsAndPartialView.Web.Strategy
{
    public interface IComponentTool
    {
        public string ComponentType { get;}
        public Task<string> GetMenu(MenuModel menuModel);
        public Task<string> GetPopularProducts(PopularProductModel popularProductModel);
        public Task<string> GetWomansDayContent(WomansDayModel womansDayModel);
    }
}
