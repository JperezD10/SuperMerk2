using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace SuperMerk2.Business
{
    public class ArchivosBL
    {
        public void serializarAXML<T>(T item)
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
        }
    }
}