using SuperMerk2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperMerk2.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(Usuario user)
        {

            return View("Index", "Home");
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            return View();
        }



    }
}
