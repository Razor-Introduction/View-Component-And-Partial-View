using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Razor.Inroduction.ViewComponentsAndPartialView.Web.Models.DatabaseContext;
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
        public async Task<IViewComponentResult> InvokeAsync(string menuType, string color)
        {
            var menuModel = _databaseContext.MenuCategories.Include(mc => mc.MenuItems)
                        .ThenInclude(mi => mi.MenuSubItems).Where(x => x.Type == menuType).ToListAsync();
            
            return View(menuModel);
        }
    }
}
