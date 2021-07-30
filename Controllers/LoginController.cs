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
            if (ModelState.IsValid)
            {
                Business.UsuarioBL g = new Business.UsuarioBL();
                var usuarioSession = g.Listar().Where(u => u.username == user.username && u.password == user.password).FirstOrDefault();
                if (usuarioSession != null)
                {
                    Session["UserSession"] = usuarioSession;
                    return RedirectToAction("Index", "Home");
                }
                else
                    return View();
            }
            else
                return View();
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            Session["UserSession"] = null;
            return RedirectToAction("LogIn", "Login");
        }



    }
}
