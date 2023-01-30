using Microsoft.AspNetCore.Mvc;
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

        public string Email { get; set; }   
        public string Password { get; set; }
        public int isValidate { get; set; }


        public Login validarSesion() {
            Login login = new Login("","",0);
            if (Email.Equals("hoho@gmail.com") && Password.Equals("1234"))
            {
                this.isValidate = 1;
                login = new Login(Email, Password, isValidate);
            }
            else {
                this.isValidate = 0;
                login = new Login(Email, Password, isValidate);
            }
            return login;
        }
    }
}
