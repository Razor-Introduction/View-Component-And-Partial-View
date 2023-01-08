using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RazorInroduction.ViewComponentsAndPartialView.Web.Models.DatabaseContext;
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
            var model = await _databaseContext.Products.Where(p => p.Category == "Child").ToListAsync();
            return View(model);
        }
    }
}
