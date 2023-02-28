using BookNexus.Models;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using System.Diagnostics;

namespace BookNexus.Controllers
{
    [DefaultBreadcrumb("Home")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Breadcrumb("Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }
        [Breadcrumb("Sitemap")]
        public IActionResult Sitemap()
        {
            return View("sitemap");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Breadcrumb("Error")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}