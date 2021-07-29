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
        // GET: Carrito
        public void DescargarXMLCarrito(int idCarrito)
        {
            {
                Carrito carrito = new CarritoBL().getDataCarritoFull(idCarrito);

                Response.ClearContent();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment; filename = carrito.xml");
    
                Response.ContentType = "text/xml";

                var serializer = new System.Xml.Serialization.XmlSerializer(carrito.GetType());
                serializer.Serialize(Response.OutputStream, carrito);
            }
        }

        // GET: Bitacora
        public void DescargarXMLBitacora(string username)
        {
            {
                List<Bitacora> bitacora = new BitacoraBL().traerBitacoraUsuario(username);

                Response.ClearContent();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment; filename = bitacora.xml");

                Response.ContentType = "text/xml";

                var serializer = new System.Xml.Serialization.XmlSerializer(bitacora.GetType());
                serializer.Serialize(Response.OutputStream, bitacora);
            }
        }
    }
}