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
        public string serializarAXML<T>(T item)
        {
            XmlSerializer xsSubmit = new XmlSerializer(item.GetType());
            var xml = "";

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, item);
                    xml = sww.ToString(); // Your XML
                }
            }

            return xml;
        }
    }
}