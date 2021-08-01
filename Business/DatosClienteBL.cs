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

        public ClienteDatos getDataClientexid(int id)
        {
            var db = new Data.GenericDataRepository<ClienteDatos>();
            ClienteDatos cliente = db.GetSingle(x => x.clienteId == id);
            if (cliente == null)
            {
                return null;
            }
            else
            {
                var db2 = new Data.GenericDataRepository<Usuario>();
                cliente.usuario = db2.GetSingle(x => x.username == cliente.username);
                return cliente;
            }

        }

        public ClienteDatos getDataCliente(string username)
        {
            var db = new Data.GenericDataRepository<ClienteDatos>();
            ClienteDatos cliente = db.GetSingle(x => x.username == username);
            if(cliente == null)
            {
                return null;
            }
            else
            {
                var db2 = new Data.GenericDataRepository<Usuario>();
                cliente.usuario = db2.GetSingle(x => x.username == cliente.username);
                return cliente;
            }

        }
    }
}