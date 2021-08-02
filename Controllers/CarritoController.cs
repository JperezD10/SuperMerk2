using SuperMerk2.Business;
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
        public ActionResult MostrarCarrito()
        {
            var carrito = Session["Carrito"] as Carrito;
            return View(carrito);
        }

        public ActionResult ListaCarrito()
        {
            Usuario usuario = Session["UserSession"] as Usuario;
            if (usuario != null)
            {
                if (usuario.esAdmin)
                {
                    CarritoBL biz = new CarritoBL();                    
                    var carrito = biz.GetAll();
                    return View(carrito);
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

        public ActionResult ListaCarritoxCliente(string user)
        {
            Usuario usuario = Session["UserSession"] as Usuario;
            if (usuario != null)
            {
                if (usuario.esAdmin)
                {
                    DatosClienteBL bizcl = new DatosClienteBL();
                    CarritoBL biz = new CarritoBL();
                    var cliente = bizcl.getDataCliente(user);
                    var carrito = biz.TraerCarritoCliente(cliente);
                    return View(carrito);
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

        public ActionResult ListarDetalleCarrito(int id)
        {
            Usuario usuario = Session["UserSession"] as Usuario;
            if (usuario != null)
            {
                if (usuario.esAdmin)
                {
                    ProductoCarritoBL biz = new ProductoCarritoBL();
                    var carrito = biz.getProductosCarritoFull(id);
                    return View(carrito);
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
        // POST: Carrito/Delete/5
        [HttpGet]
        public ActionResult EliminarProducto(int carrito, int productoEliminar)
        {
            Business.CarritoBL c = new Business.CarritoBL();
            var carritoActualziado = c.borrarItemCarrito(carrito, productoEliminar);
            Session["Carrito"] = carritoActualziado;
            //Log Evento
            new BitacoraController().RegistrarEvento(Session["UserSession"] as Usuario, "Elimino un producto de su carrito");
            return View("MostrarCarrito", carritoActualziado);
        }


    }
}
