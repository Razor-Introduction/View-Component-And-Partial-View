using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Razor.Inroduction.ViewComponentsAndPartialView.Web.Constant;
using Razor.Inroduction.ViewComponentsAndPartialView.Web.Strategy;
using RazorInroduction.ViewComponentsAndPartialView.Web.Models.DatabaseContext;
using RazorInroduction.ViewComponentsAndPartialView.Web.Models.Strategy;
using RazorInroduction.ViewComponentsAndPartialView.Web.Models.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RazorInroduction.ViewComponentsAndPartialView.Web.Controllers
{
    public class ChildController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IComponentTool _menuTool;
        public ChildController(DatabaseContext databaseContext, IComponentTool menuTool)
        {
            _databaseContext = databaseContext;
            _menuTool = menuTool;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _databaseContext.Products.Where(p => p.Category == "Child").ToListAsync();
            var viewModel = await GetModel();

            viewModel.Products = products;

            return View(viewModel);
        }

        [NonAction]
        private async Task<CategoryViewModel> GetModel()
        {
            if (_menuTool.ComponentType == Constants.ComponentType.ViewComponent)
            {
                return new CategoryViewModel()
                {
                    MenuModel = new MenuModel { Type = "Child" },
                    PopularProductModel = new PopularProductModel { Category = "Child", Count = 6 }
                };
            }
            else if (_menuTool.ComponentType == Constants.ComponentType.PartialView)
            {
                var menuModel = await _databaseContext.MenuCategories
              .Include(mc => mc.MenuItems)
              .ThenInclude(mi => mi.MenuSubItems)
              .Where(x => x.Type == "Child").ToListAsync();

                var color = await _databaseContext.BaseColors.Where(bc => bc.Category == "Child").ToListAsync();

                var popularProducts = await _databaseContext.Products.Where(p => p.Category == "Child").Take(6).ToListAsync();

                var menuViewModel = new MenuViewModel() { Menu = menuModel.First(), Color = color.First() };

                var popularProductViewModel = new PopularProductViewModel() { Products = popularProducts, Color = color.First() };

                return new CategoryViewModel()
                {
                    MenuModel = new MenuModel() { menuViewModel = menuViewModel, Type = "Child" },
                    PopularProductModel = new PopularProductModel() { PopularProductViewModel = popularProductViewModel, Category = "Child", Count = 6 }
                };
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}
