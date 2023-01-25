using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using SmartBreadcrumbs.Attributes;
namespace MvcMovie.Controllers
{
    [DefaultBreadcrumb("Home")]

    public class HelloWorldController : Controller
    {
        // 
        // GET: /HelloWorld/
        public IActionResult Index()
        {
            return View();
        }

        // GET: /HelloWorld/Welcome/ 
        // Requires using System.Text.Encodings.Web;

        [Breadcrumb("Visitas")]
        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }
    }
}