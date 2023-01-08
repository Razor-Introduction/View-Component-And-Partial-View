using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Razor.Inroduction.ViewComponentsAndPartialView.Web.Models;
using Razor.Inroduction.ViewComponentsAndPartialView.Web.Models.DatabaseContext;
using Razor.Inroduction.ViewComponentsAndPartialView.Web.Models.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Razor.Inroduction.ViewComponentsAndPartialView.Web.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly DatabaseContext _databaseContext;
        public MenuViewComponent(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task<IViewComponentResult> InvokeAsync(string menuType)
        {
            var menuModel = await _databaseContext.MenuCategories
                .Include(mc => mc.MenuItems)
                .ThenInclude(mi => mi.MenuSubItems)
                .Where(x => x.Type == menuType).ToListAsync();

            var color = await _databaseContext.BaseColors.Where(bc => bc.Category == menuType).ToListAsync();

            MenuViewModel menuViewModel = new()
            {
                Menu = menuModel.First() ?? new Menu(),
                Color =color.First() ?? new()   
            };

            return View(menuViewModel);
        }
    }
}
