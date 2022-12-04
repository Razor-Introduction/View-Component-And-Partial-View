using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Razor.Inroduction.ViewComponentsAndPartialView.Web.Models;
using System.Diagnostics;
using System.Linq;

namespace Razor.Inroduction.ViewComponentsAndPartialView.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly DatabaseContext _databaseContext;
        public HomeController(ILogger<HomeController> logger,DatabaseContext databaseContext)
        {
            _logger = logger;
            _databaseContext = databaseContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Man()
        {
            var model = new MenuViewModel
            {
                MenuItems = _databaseContext.MenuItems.Where(mi => mi.Type == "Man").ToList(),
                Color = "bg-primary"
            };
            return View(model);
        }

        public IActionResult Woman()
        {
            var model = new MenuViewModel
            {
                MenuItems = _databaseContext.MenuItems.Where(mi => mi.Type == "Woman").ToList(),
                Color = "bg-danger"
            };
            return View(model);
        }

        public IActionResult Child()
        {
            var model = new MenuViewModel
            {
                MenuItems = _databaseContext.MenuItems.Where(mi => mi.Type == "Child").ToList(),
                Color = "bg-success"
            };
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