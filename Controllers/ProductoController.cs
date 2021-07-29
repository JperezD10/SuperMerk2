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
            ProductoBL biz = new ProductoBL();
            var product = biz.getAll();
            return View(product);
        }
        [HttpGet]
        public ActionResult ListProductos()
        {
            ProductoBL biz = new ProductoBL();
            var product = biz.getAll();
            return View(product);
        }
        [HttpGet]
        public ActionResult ListProductosxCategory(int id)
        {
            ProductoBL biz = new ProductoBL();
            var product = biz.getProductosPorCategoria(id);
            return View("ListAllProductos", product);
        }

        [HttpGet]
        public ActionResult DetalleProducto(int id)
        {
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
                return View();
            }
            else
            {
                return View();
            }

        }

        [HttpGet]
        public ActionResult EditProducto(int id)
        {
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
            ProductoBL biz = new ProductoBL();
            var product = biz.getProductosPorCategoria(id);
            return View(product);
        }
        [HttpGet]
        public ActionResult EliminarProductos(int id)
        {
            ProductoBL biz = new ProductoBL();

            biz.eliminarProducto(biz.getDataProducto(id));
            return RedirectToAction("ListProductos", "Producto");
        }


    }
}
