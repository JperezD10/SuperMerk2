using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperMerk2.Business;
using SuperMerk2.Models;

namespace SuperMerk2.Controllers
{
    public class ProductoController : Controller
    {
        [HttpGet]
        public ActionResult ListAllProductos()
        {
            RedirectLogin();
            ProductoBL biz = new ProductoBL();
            var product = biz.getAll();
            return View(product);
        }
        [HttpGet]
        public ActionResult ListProductos()
        {
            RedirectLogin();
            ProductoBL biz = new ProductoBL();
            var product = biz.getAll();
            Business.CategoriaBL bL = new CategoriaBL();
            foreach (var p in product)
            {
                p.categoria = bL.GetAll().Where(c => c.categoriaId == p.categoriaId).FirstOrDefault();
            }
            return View(product);
        }
        [HttpGet]
        public ActionResult ListProductosxCategory(int id)
        {
            RedirectLogin();
            ProductoBL biz = new ProductoBL();
            var product = biz.getProductosPorCategoria(id);
            return View("ListAllProductos", product);
        }

        [HttpGet]
        public ActionResult DetalleProducto(int id)
        {
            RedirectLogin();
            ProductoBL biz = new ProductoBL();
            var product = biz.getDataProducto(id);
            return View(product);
        }

        [HttpGet]
        public ActionResult CreateProducto()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateProducto(Producto product)
        {
            if (ModelState.IsValid)
            {
                ProductoBL biz = new ProductoBL();
                biz.altaProducto(product);
                //Log Evento
                new BitacoraController().RegistrarEvento(Session["UserSession"] as Usuario, "Creo un producto");
                return RedirectToAction("ListProductos");
            }
            else
            {
                return View();
            }

        }

        [HttpGet]
        public ActionResult EditProducto(int id)
        {
            RedirectLogin();
            ProductoBL biz = new ProductoBL();
            var producto = biz.getDataProducto(id);
            return View(producto);
        }
        [HttpPost]
        public ActionResult EditProducto(Producto product)
        {
            if (ModelState.IsValid)
            { 
                ProductoBL biz = new ProductoBL();
                biz.modificarProducto(product);
                //Log Evento
                new BitacoraController().RegistrarEvento(Session["UserSession"] as Usuario, "Modifico un producto");
                return RedirectToAction("ListProductos", "Producto");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult ProductosCategoria(int id)
        {
            RedirectLogin();
            ProductoBL biz = new ProductoBL();
            var product = biz.getProductosPorCategoria(id);
            return View(product);
        }
        [HttpGet]
        public ActionResult EliminarProductos(int id)
        {
            RedirectLogin();
            ProductoBL biz = new ProductoBL();
            biz.eliminarProducto(biz.getDataProducto(id));
            //Log Evento
            new BitacoraController().RegistrarEvento(Session["UserSession"] as Usuario, "Elimino un producto");
            return RedirectToAction("ListProductos", "Producto");
        }

        [HttpGet]
        public ActionResult AddToCart(Producto product)
        {
            RedirectLogin();
            CarritoBL cart = new CarritoBL();
            ///????????????????????????????
            return RedirectToAction("ListProductosxCategory", "Producto", new { id = product.categoriaId });
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
