using SuperMerk2.Business;
using SuperMerk2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperMerk2.Controllers
{
    public class BitacoraController : Controller
    {
        // GET: Bitacora
        public ActionResult ListarBitacora()
        {
            Usuario usuario = Session["UserSession"] as Usuario;
            if (usuario != null)
            {
                if (usuario.esAdmin)
                {           
                    RedirectLogin();
                    BitacoraBL biz = new BitacoraBL();
                    var bitacora = biz.traerBitacoraCompleta();
                   return View(bitacora);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("LogIn", "Login");
            }

        }
        [HttpPost]
        public ActionResult ListarBitacoraPorUsuario(string filtro)
        {
            Usuario usuario = Session["UserSession"] as Usuario;
            if (usuario != null)
            {
                if (usuario.esAdmin)
                {            
                    BitacoraBL biz = new BitacoraBL();
                    var bitacora = biz.traerBitacoraUsuario(filtro);
                    TempData["UsuarioElegido"] = filtro;
                    TempData.Keep();
                    return PartialView("ListarBitacora", bitacora);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("LogIn", "Login");
            }

        }


        public void RegistrarEvento(Usuario user, string descripcion)
        {
            BitacoraBL biz = new BitacoraBL();
            biz.registrarEvento(user, descripcion);
        }

        private void RedirectLogin()
        {
            if (Session["UserSession"] == null)
            {
                RedirectToAction("LogIn", "Login");
            }
        }
    }
}
