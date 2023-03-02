using Azure;
using Microsoft.AspNetCore.Mvc;
using BookNexus.Data;
using Microsoft.EntityFrameworkCore;


namespace BookNexus.Controllers
{
    public class LoginController : Controller
    {

        public ActionResult Index()
        {
            return RedirectToAction("Inicio");
        }
        public ActionResult Inicio()
        {
            return View("Index");
        }
        public ActionResult SignUp()
        {
            return View("sign_up");
        }
        public ActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return View("sign_in");
        }
    }
}
