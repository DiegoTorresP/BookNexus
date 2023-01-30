using Azure;
using Microsoft.AspNetCore.Mvc;
using BookNexus.Data;

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

        [HttpPost]
        public Login validarSesion(string Email, string Password)
        {
            Login obj_login = new Login(Email,Password,0);
            obj_login.Email = Email;
            obj_login.Password = Password;
            obj_login.validarSesion();
            return obj_login;
        }
        //[HttpPost]
        //public ActionResult Action(string param1, string param2)
        //{
        //    // Código para manejar la solicitud y generar una respuesta
        //    return Json(response); // Devuelve la respuesta en formato JSON
        //}
    }
}
