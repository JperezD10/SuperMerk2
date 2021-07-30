using SuperMerk2.Business;
using SuperMerk2.Models;
using System.Collections.Generic;
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
            return View("Index", "Home");
        }

        [HttpGet]
        public ActionResult EditUsuario(string user)
        {

            return View(user);
        }

        [HttpPost]
        public ActionResult EditUsuario(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
