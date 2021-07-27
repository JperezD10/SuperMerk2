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
        public ActionResult ListProductos()
        {
            ProductoBL biz = new ProductoBL();
            var product = biz.getAll();
            return View(product);
        }

        [HttpGet]
        public ActionResult ListAllProductos()
        {
            ProductoBL biz = new ProductoBL();
            var product = biz.getAll();
            return View(product);
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
            return View();
        }

        [HttpGet]
        public ActionResult EditProducto()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EditProducto(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult ProductosCategoria(int id)
        {
            ProductoBL biz = new ProductoBL();
            var product = biz.getProductosPorCategoria(id);
            return View(product);
        }


    }
}
