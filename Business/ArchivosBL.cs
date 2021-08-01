using SuperMerk2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Serialization;

namespace SuperMerk2.Business
{
    public class ArchivosBL
    {
        public void serializarAXML<T>(T item, Stream salida)
        {
            XmlSerializer xsSubmit = new XmlSerializer(item.GetType());

            using (var sww = new StringWriter())
            {
                xsSubmit.Serialize(salida, item);
            }
        }
    }
}