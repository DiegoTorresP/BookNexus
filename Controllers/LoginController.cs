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
            HttpContext.Session.Remove("_Name");
            HttpContext.Session.Remove("_Age");
            return View("sign_in");
        }
        [HttpPost]
        public Login validarSesion(string Email, string Password)
        {
            Login obj_login = new Login(Email, Password, 0);
            obj_login.Email = Email;
            obj_login.Password = Password;
            obj_login.validarSesion();
            return obj_login;
        }
    }
}
