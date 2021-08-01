using SuperMerk2.Business;
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
                UsuarioBL g = new UsuarioBL();
                var usuarioSession = g.Listar().Where(u => u.username == user.username && u.password == user.password && u.Habilitado == true).FirstOrDefault();

                if (usuarioSession != null)
                {
                    ClienteDatos cliente = new DatosClienteBL().getDataCliente(usuarioSession.username);

                    Session["ClientSession"] = cliente;
                    Session["UserSession"] = usuarioSession;
                    //Log Evento
                    new BitacoraController().RegistrarEvento(Session["UserSession"] as Usuario, "Se logeo el usuario");
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
