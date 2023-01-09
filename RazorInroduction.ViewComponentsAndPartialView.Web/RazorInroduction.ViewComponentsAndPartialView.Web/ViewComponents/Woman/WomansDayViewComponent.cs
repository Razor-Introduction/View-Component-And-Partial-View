using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RazorInroduction.ViewComponentsAndPartialView.Web.Models.DatabaseContext;
using RazorInroduction.ViewComponentsAndPartialView.Web.Models.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace RazorInroduction.ViewComponentsAndPartialView.Web.ViewComponents.Woman
{
    public class WomansDayViewComponent : ViewComponent
    {
        private readonly DatabaseContext _databaseContext;
        public WomansDayViewComponent(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = await _databaseContext.Products.Where(p => p.Category == "Woman").Take(8).ToListAsync();
           
            WomansDayViewModel model = new()
            {
                Products = products
            };

            return View(model);
        }
    }
}
