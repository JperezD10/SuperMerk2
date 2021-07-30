using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperMerk2.Business;
using SuperMerk2.Models;

namespace SuperMerk2.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult ListCategorias()
        {
            RedirectLogin();
            CategoriaBL biz = new CategoriaBL();
            var product = biz.GetAll();
            return View(product);
        }

        [HttpGet]
        public ActionResult CreateCategoria()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCategoria(Categoria cat)
        {
            return View();
        }

        [HttpGet]
        public ActionResult EditCategoria()
        {
            CategoriaBL biz = new CategoriaBL();
           // var product = biz.getDataCategoria(id);
            return View();
        }
        [HttpPost]
        public ActionResult EditCategoria(int id)
        {
            return View();
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
