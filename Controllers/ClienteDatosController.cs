using SuperMerk2.Business;
using SuperMerk2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperMerk2.Controllers
{
    public class ClienteDatosController : Controller
    {
        // GET: ClienteDatos
        public ActionResult Index()
        {
            return View();
        }

        // GET: ClienteDatos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateClienteData()
        {
            ClienteDatos c = new ClienteDatos();
            var user = Session["UserSession"] as Usuario;
            c.username = user.username;
            c.usuario = user;
            return View(c);
        }

        [HttpPost]
        public ActionResult CreateClienteData(ClienteDatos cliente)
        {
            if (ModelState.IsValid)
            {
                DatosClienteBL c = new DatosClienteBL();
                try
                {
                    c.altaDatosCliente(cliente);

                    var datos = c.getDataCliente(cliente.username);

                    Session["ClientSession"] = datos;
                    return RedirectToAction("Index","Home");
                }
                catch
                {
                    return View();
                }
            }
            return View();

        }        
    }
}
