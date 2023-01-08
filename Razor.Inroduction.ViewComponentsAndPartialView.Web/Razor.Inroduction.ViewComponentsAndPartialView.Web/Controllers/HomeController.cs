using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Razor.Inroduction.ViewComponentsAndPartialView.Web.Models;
using Razor.Inroduction.ViewComponentsAndPartialView.Web.Models.DatabaseContext;
using Razor.Inroduction.ViewComponentsAndPartialView.Web.Models.ViewModels;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Razor.Inroduction.ViewComponentsAndPartialView.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly DatabaseContext _databaseContext;
        public HomeController(ILogger<HomeController> logger, DatabaseContext databaseContext)
        {
            _logger = logger;
            _databaseContext = databaseContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Man()
        {
            var model = await _databaseContext.Products.Where(p => p.Category == "Man").ToListAsync();
            return View(model);
        }

        public async Task<IActionResult> Woman()
        {
            var model = await _databaseContext.Products.Where(p => p.Category == "Woman").ToListAsync();
            return View(model);
        }

        public async Task<IActionResult> Child()
        {
            var model = await _databaseContext.Products.Where(p => p.Category == "Child").ToListAsync();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}