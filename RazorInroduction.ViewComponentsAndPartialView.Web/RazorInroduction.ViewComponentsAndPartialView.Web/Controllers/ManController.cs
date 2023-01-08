using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RazorInroduction.ViewComponentsAndPartialView.Web.Models.DatabaseContext;
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
            var model = await _databaseContext.Products.Where(p => p.Category == "Man").ToListAsync();
            return View(model);
        }
    }
}
