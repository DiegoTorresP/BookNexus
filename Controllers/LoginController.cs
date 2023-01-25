using Microsoft.AspNetCore.Mvc;

namespace BookNexus.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("LogOut");
        }
        public ActionResult LogOut()
        {
            return View("Index");
        }

        public ActionResult validarSesion()
        {
            return View("../../Home/Index");
        }
    }
}
