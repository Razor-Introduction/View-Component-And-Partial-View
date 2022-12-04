using Microsoft.AspNetCore.Mvc;
using Razor.Inroduction.ViewComponentsAndPartialView.Web.Models;
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
        public async Task<IViewComponentResult> InvokeAsync(string type,string color)
        {
            MenuViewModel viewModel = new()
            {
                MenuItems = _databaseContext.MenuItems.Where(mi => mi.Type == type).ToList(),
                Color = color
            };

            return View(viewModel);
        }
    }
}
