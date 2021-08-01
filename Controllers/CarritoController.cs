using SuperMerk2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperMerk2.Controllers
{
    public class CarritoController : Controller
    {
        // GET: Carrito
        public ActionResult MostrarCarrito()
        {
            var carrito = Session["Carrito"] as Carrito;
            return View(carrito);
        }

        // GET: Carrito/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Carrito/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Carrito/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Carrito/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Carrito/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Carrito/Delete/5
        [HttpGet]
        public ActionResult EliminarProducto(int carrito, int productoEliminar)
        {
            try
            {
                Business.CarritoBL c = new Business.CarritoBL();
                var carritoActualziado = c.borrarItemCarrito(carrito, productoEliminar);
                Session["Carrito"] = carritoActualziado;
                return View("MostrarCarrito", carritoActualziado);
            }
            catch
            {
                return View();
            }
        }
    }
}
