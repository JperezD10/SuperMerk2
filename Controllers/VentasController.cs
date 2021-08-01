using SuperMerk2.Business;
using SuperMerk2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperMerk2.Controllers
{
    public class VentasController : Controller
    {
        // GET: Ventas/Create
        [HttpPost]
        public ActionResult Checkout(int idCarrito)
        {
            VentasBL bl = new VentasBL();
            //Verifico que nada exceda stock por las dudas
            Carrito carr = new CarritoBL().getDataCarritoFull(idCarrito);
            carr.clienteDatos = new ClienteDatos();
            var usuario = Session["UserSession"] as Usuario;
            carr.clienteDatos.username = usuario.username;
            if (bl.SuficienteStock(carr))
            {
                //Si hay suficiente stock, hago checkout
                bl.Checkout(carr);
                Session["Carrito"] = null;
            }
            return RedirectToAction("Index","Home");
        }

        
    }
}
