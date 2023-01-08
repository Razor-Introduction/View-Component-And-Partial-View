using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RazorInroduction.ViewComponentsAndPartialView.Web.Models.DatabaseContext;
using RazorInroduction.ViewComponentsAndPartialView.Web.Models.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace RazorInroduction.ViewComponentsAndPartialView.Web.Controllers
{
    public class WomanController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        public WomanController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _databaseContext.Products.Where(p => p.Category == "Woman").ToListAsync();

            var menuModel = await _databaseContext.MenuCategories
               .Include(mc => mc.MenuItems)
               .ThenInclude(mi => mi.MenuSubItems)
               .Where(x => x.Type == "Woman").ToListAsync();

            var color = await _databaseContext.BaseColors.Where(bc => bc.Category == "Woman").ToListAsync();

            var popularProducts = await _databaseContext.Products.Where(p => p.Category == "Woman").Take(6).ToListAsync();

            var womanDaysProducts = await _databaseContext.Products.Where(p => p.Category == "Woman").Take(8).ToListAsync();

            WomanCategoryViewModel viewModel = new()
            {
                Products = products,
                MenuViewModel = new() { Menu = menuModel.First(), Color = color.First() },
                PopularProductViewModel = new() { Products = popularProducts, Color = color.First() },
                WomansDayViewModel = new() { Products = womanDaysProducts}
            };

            return View(viewModel);
        }
    }
}
