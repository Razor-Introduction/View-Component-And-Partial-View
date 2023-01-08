using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Razor.Inroduction.ViewComponentsAndPartialView.Web.Models.DatabaseContext;
using System.Linq;
using System.Threading.Tasks;

namespace Razor.Inroduction.ViewComponentsAndPartialView.Web.Controllers
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
            var model = await _databaseContext.Products.Where(p => p.Category == "Woman").ToListAsync();
            return View(model);
        }
    }
}
