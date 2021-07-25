using SuperMerk2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperMerk2.Business
{
    public class DatosClienteBL
    {
        //Alta de datos
        public void altaDatosCliente(ClienteDatos datos)
        {
            var db = new Data.GenericDataRepository<ClienteDatos>();
            db.Add(datos);
        }

        //Modificacion de datos
        public void modificarDatosCliente(ClienteDatos datos)
        {
            var db = new Data.GenericDataRepository<ClienteDatos>();
            db.Update(datos, x => x.username == datos.username);
        }

        public ClienteDatos getDataCliente(string username)
        {
            var db = new Data.GenericDataRepository<ClienteDatos>();
            return db.GetSingle(x => x.username == username);
        }
    }
}