using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using SmartBreadcrumbs.Attributes;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        // 
        // GET: /HelloWorld/
        [Breadcrumb("Tu Perfil")]
        public IActionResult Index()
        {
            string name = HttpContext.Session.GetString("NameUser");
            ViewBag.Usuario = name;
            return View(model: name);
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