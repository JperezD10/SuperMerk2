using SuperMerk2.Business;
using SuperMerk2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperMerk2.Controllers
{
    public class BitacoraController : Controller
    {
        // GET: Bitacora
        public ActionResult ListarBitacora()
        {
            BitacoraBL biz = new BitacoraBL();
            var bitacora = biz.traerBitacoraCompleta();
            return View(bitacora);
        }

        public ActionResult ListarBitacoraPorUsuario(Usuario user)
        {
            BitacoraBL biz = new BitacoraBL();
            var bitacora = biz.traerBitacoraUsuario(user.username);
            return View(bitacora);
        }
    }
}
