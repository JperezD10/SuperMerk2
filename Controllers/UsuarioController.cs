using SuperMerk2.Business;
using SuperMerk2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SuperMerk2.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet]
        public ActionResult ListUsuario()
        {
            Usuario usuario = Session["UserSession"] as Usuario;
            if (usuario != null)
            {
                if (usuario.esAdmin)
                {
                    UsuarioBL biz = new UsuarioBL();
                    var user = biz.Listar();
                    return View(user);
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

        [HttpGet]
        public ActionResult CreateUsuario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUsuario(Usuario user)
        {
            UsuarioBL gestor = new UsuarioBL();
            user.Habilitado = true;
            if (gestor.altaUsuario(user))
            {
                Session["ErrorRegistro"] = null;
                //ClienteDatos cliente = new ClienteDatos();
                //cliente.usuario = user;
                //cliente.username = user.username;
                //new DatosClienteBL().altaDatosCliente(cliente);
                return RedirectToAction("LogIn", "Login");
            }
            else
            {
                Session["ErrorRegistro"] = "Usuario existente";
                return View();
            }
        }

        [HttpGet]
        public ActionResult EditUsuario(string username)
        {
            if (Session["UserSession"] == null)
            {
                RedirectToAction("LogIn", "Login");
            }
            UsuarioBL usuarioBL = new UsuarioBL();
            var usuario = usuarioBL.Listar().Where(u => u.username == username).FirstOrDefault();
            return View(usuario);
        }

        [HttpPost]
        public ActionResult EditUsuario(Usuario usuario)
        {
            Usuario user = Session["UserSession"] as Usuario;
            if (ModelState.IsValid)
            {
                UsuarioBL usuarioBL = new UsuarioBL();
                var usercompare = usuarioBL.Listar().Where(u => u.username == usuario.username).FirstOrDefault();
                if (usercompare != null && usercompare.username == usuario.username)
                {
                    Session["UsernameExistente"] = null;
                    usuarioBL.EditUsuario(usuario, usercompare.username);
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    
                    return RedirectToAction("ListUsuario");
                }
            }
            else
                return View("EditUsuario", user);
        }

        [HttpGet]
        public ActionResult EditUsuarioAdmin(string username)
        {
            if (Session["UserSession"] == null)
            {
                RedirectToAction("LogIn", "Login");
            }
            UsuarioBL usuarioBL = new UsuarioBL();
            var usuario = usuarioBL.Listar().Where(u => u.username == username).FirstOrDefault();
            return View(usuario);
        }

        [HttpPost]
        public ActionResult EditUsuarioAdmin(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                UsuarioBL usuarioBL = new UsuarioBL();
                var usercompare = usuarioBL.Listar().Where(u => u.username == usuario.username).FirstOrDefault();
                if (usercompare != null)
                {
                    Session["UsernameExistente"] = null;
                    usuarioBL.EditUsuario(usuario, usercompare.username);
                    return RedirectToAction("ListUsuario");
                }
                else
                {

                    return RedirectToAction("ListUsuario");
                }
            }
            else
                return View("EditUsuario");
        }


        [HttpGet]
        public ActionResult DesactivarUsuario(string user)
        {
            UsuarioBL usuarioBL = new UsuarioBL();
            try
            {
                usuarioBL.DesactivarUsuario(user);
                return RedirectToAction("ListUsuario","Usuario");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult HabilitarUsuario(string user)
        {
            UsuarioBL usuarioBL = new UsuarioBL();
            try
            {
                usuarioBL.HabilitarUsuario(user);
                return RedirectToAction("ListUsuario", "Usuario");
            }
            catch
            {
                return View();
            }
        }


    }
}
