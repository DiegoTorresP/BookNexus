using BookNexus.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Web.Mvc;
using ActionResult = Microsoft.AspNetCore.Mvc.ActionResult;
using JsonResult = System.Web.Mvc.JsonResult;

namespace BookNexus.Data
{

    public class Login
    {
        public Login(string email, string password, int isValidate)
        {
            Email = email;
            Password = password;
            this.isValidate = isValidate;
        }
        public readonly BookNexusContext _context;
        public string Email { get; set; }   
        public string Password { get; set; }
        public int isValidate { get; set; }
        public const string SessionKeyName = "_Name";
        public const string SessionKeyAge = "_Age";
       
        public Login validarSesion() {
            Login login = new Login("","",0);
            login = new Login(Email, Password, isValidate);
            return login;
        }

    }
}
