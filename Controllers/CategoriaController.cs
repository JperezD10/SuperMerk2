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
            Usuario usuario = Session["UserSession"] as Usuario;
            if (usuario != null)
            {
                if (usuario.esAdmin)
                {
                    CategoriaBL biz = new CategoriaBL();
                    var product = biz.GetAll();
                    return View(product);
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
        public ActionResult EditCategoria( int idCategoria)
        {
            CategoriaBL cat = new CategoriaBL();
            var categoria = cat.getDataCategoria(idCategoria);
            return View(categoria);
        }
        [HttpPost]
        public ActionResult EditCategoria(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                CategoriaBL cat = new CategoriaBL();
                cat.modificarCategoria(categoria);
                //Log Evento
                new BitacoraController().RegistrarEvento(Session["UserSession"] as Usuario, "Modifico una categoria");
                return RedirectToAction("ListCategorias", "Categoria");
            }
            else
                return View();
        }

        [HttpGet]
        public ActionResult DeleteCategoria(int idCategoria)
        {
            CategoriaBL cat = new CategoriaBL(); 
            var categoria = cat.getDataCategoria(idCategoria);
            cat.eliminarCategoria(categoria);
            //Log Evento
            new BitacoraController().RegistrarEvento(Session["UserSession"] as Usuario, "Borro una categoria");
            return RedirectToAction("ListCategorias", "Categoria");
        }
    }
}
