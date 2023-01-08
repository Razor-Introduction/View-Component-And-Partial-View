using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using RazorInroduction.ViewComponentsAndPartialView.Web.Models;
using RazorInroduction.ViewComponentsAndPartialView.Web.Models.DatabaseContext;
using RazorInroduction.ViewComponentsAndPartialView.Web.Models.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace RazorInroduction.ViewComponentsAndPartialView.Web.ViewComponents.Common
{
    public class PopularProductsViewComponent : ViewComponent
    {
        private readonly DatabaseContext _databaseContext;
        public PopularProductsViewComponent(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task<IViewComponentResult> InvokeAsync(string category, int count)
        {
            var products = await _databaseContext.Products.Where(p => p.Category == category).Take(count).ToListAsync();
            var color = await _databaseContext.BaseColors.Where(bc => bc.Category == category).ToListAsync();

            if (products.Count > 0)
            {
                PopularProductViewModel model = new()
                {
                    Products = products ?? new(),
                    Color = color.First() ?? new()
                };

                return View(model);
            }

            return View(new PopularProductViewModel());
        }


    }
}
