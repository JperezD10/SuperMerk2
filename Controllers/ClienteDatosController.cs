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
        [HttpGet]
        public ActionResult DetalleCliente()
        {
            if (Session["ClientSession"] == null)
            {
                return RedirectToAction("CreateClienteData", "ClienteDatos");
            }
            if (Session["UserSession"] == null)
            {
                RedirectToAction("LogIn", "Login");
            }
            ClienteDatos c = new ClienteDatos();
            DatosClienteBL biz = new DatosClienteBL();
            var user = Session["UserSession"] as Usuario;
            var cliente = biz.getDataCliente(user.username);
            return View(cliente);
        }

        [HttpPost]
        public ActionResult DetalleCliente(ClienteDatos cliente)
        {
            if (ModelState.IsValid)
            {
                DatosClienteBL biz = new DatosClienteBL();
                var user = Session["UserSession"] as Usuario;
                cliente.usuario = user;
                biz.modificarDatosCliente(cliente);
                Session["ClientSession"] = cliente;
                return View(cliente);
            }
            else
            {
                return View();
            }
        }

        // GET: ClienteDatos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateClienteData()
        {
            if (Session["UserSession"] == null)
            {
                RedirectToAction("LogIn", "Login");
            }
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
