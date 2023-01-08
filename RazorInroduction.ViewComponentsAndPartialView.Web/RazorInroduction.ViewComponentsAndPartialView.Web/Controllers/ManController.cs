using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RazorInroduction.ViewComponentsAndPartialView.Web.Models.DatabaseContext;
using RazorInroduction.ViewComponentsAndPartialView.Web.Models.ViewModels;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading.Tasks;

namespace RazorInroduction.ViewComponentsAndPartialView.Web.Controllers
{
    public class ManController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        public ManController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _databaseContext.Products.Where(p => p.Category == "Man").ToListAsync();

            var menuModel = await _databaseContext.MenuCategories
               .Include(mc => mc.MenuItems)
               .ThenInclude(mi => mi.MenuSubItems)
               .Where(x => x.Type == "Man").ToListAsync();

            var color = await _databaseContext.BaseColors.Where(bc => bc.Category == "Man").ToListAsync();

            var popularProducts = await _databaseContext.Products.Where(p => p.Category == "Man").Take(6).ToListAsync();

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
