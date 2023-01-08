using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RazorInroduction.ViewComponentsAndPartialView.Web.Models.DatabaseContext;
using RazorInroduction.ViewComponentsAndPartialView.Web.Models.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace RazorInroduction.ViewComponentsAndPartialView.Web.Controllers
{
    public class ChildController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        public ChildController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _databaseContext.Products.Where(p => p.Category == "Child").ToListAsync();

            var menuModel = await _databaseContext.MenuCategories
               .Include(mc => mc.MenuItems)
               .ThenInclude(mi => mi.MenuSubItems)
               .Where(x => x.Type == "Child").ToListAsync();

            var color = await _databaseContext.BaseColors.Where(bc => bc.Category == "Child").ToListAsync();

            var popularProducts = await _databaseContext.Products.Where(p => p.Category == "Child").Take(6).ToListAsync();

            CategoryViewModel viewModel = new()
            {
                Products = products,
                MenuViewModel = new() { Menu = menuModel.First(), Color = color.First() },
                PopularProductViewModel = new() { Products = popularProducts, Color = color.First() }
            };

            return View(viewModel);
        }
    }
}
