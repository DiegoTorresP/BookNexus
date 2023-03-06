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

        public ActionResult SignIn(int toInitSession)
        {
            ViewBag.toInitSession = TempData["toInitSession"];
            return View("sign_in");
        }
        public ActionResult LogOut()
        {
            HttpContext.Session.Clear();
            if (TempData.ContainsKey("iAplicaAlerta"))
            {
                // TempData["iAplicaAlerta"] tiene datos
                ViewBag.isExpired = TempData["iAplicaAlerta"];
            }
            else
            {
                // TempData["iAplicaAlerta"] no tiene datos o no existe
                ViewBag.isExpired = null;
            }
            return View("Index");
        }
    }
}
