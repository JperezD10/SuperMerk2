using SuperMerk2.Business;
using SuperMerk2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperMerk2.Controllers
{
    public class ArchivoController : Controller
    {
        [HttpGet]
        public void DescargarXMLCarrito(int idCarrito)
        {
            ArchivosBL archivo = new ArchivosBL();
            Carrito carrito = new CarritoBL().getDataCarritoFull(idCarrito);

            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename = carrito.xml");

            Response.ContentType = "text/xml";

            archivo.serializarAXML(carrito, Response.OutputStream);
            Response.End();
        }

        [HttpGet]
        public void DescargarXMLBitacora(string username)
        {
            if(username != null)
            {
                ArchivosBL archivo = new ArchivosBL();
                List<Bitacora> bitacora = new BitacoraBL().traerBitacoraUsuario(username);

                Response.ClearContent();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment; filename = bitacora.xml");

                Response.ContentType = "text/xml";

                archivo.serializarAXML(bitacora, Response.OutputStream);
                Response.End();
            }
            else
            {
                ArchivosBL archivo = new ArchivosBL();
                List<Bitacora> bitacora = new BitacoraBL().traerBitacoraCompleta();

                Response.ClearContent();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment; filename = bitacora.xml");

                Response.ContentType = "text/xml";

                archivo.serializarAXML(bitacora, Response.OutputStream);
                Response.End();
            }

        }
    }
}
