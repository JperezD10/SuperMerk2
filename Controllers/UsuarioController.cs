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
            RedirectLogin();
            UsuarioBL biz = new UsuarioBL();
            var user = biz.Listar();
            return View(user);
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
            if (gestor.altaUsuario(user))
            {
                Session["ErrorRegistro"] = null;
                ClienteDatos cliente = new ClienteDatos();
                cliente.usuario = user;
                cliente.username = user.username;
                new DatosClienteBL().altaDatosCliente(cliente);
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
            UsuarioBL usuarioBL = new UsuarioBL();
            var usuario = usuarioBL.Listar().Where(u => u.username == username).FirstOrDefault();
            return View(usuario);
        }

        [HttpPost]
        public ActionResult EditUsuario(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                UsuarioBL usuarioBL = new UsuarioBL();
                var usercompare = usuarioBL.Listar().Where(u => u.username == usuario.username).FirstOrDefault();
                if (usercompare != null && usercompare.username == usuario.username)
                {
                    Session["UsernameExistente"] = "Ese nombre de usuario esta ocupado por otro usuario";
                    return View();
                }
                else if (usercompare != null && usercompare.username != usuario.username)
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
                return View();
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private void RedirectLogin()
        {
            if (Session["UserSession"]==null)
            {
                RedirectToAction("LogIn", "Login");
            }
        }
    }
}
