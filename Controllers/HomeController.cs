using SuperMerk2.Business;
using SuperMerk2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperMerk2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            int idCarrito = 1;
            ProductoCarritoBL prodcarrbl = new ProductoCarritoBL();
            ProductoDeCarrito prod = prodcarrbl.getDataProductoCarrito(2);
            prod.cantidadItems = 6;
            prodcarrbl.actualizarProdACarrito(prod);
            string lala = "";
            return View();
        }
    }
}
