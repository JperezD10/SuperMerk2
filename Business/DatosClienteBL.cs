using SuperMerk2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperMerk2.Business
{
    public class DatosClienteBL
    {
        public ClienteDatos getDataCategoria(string username)
        {
            var db = new Data.GenericDataRepository<ClienteDatos>();
            return db.GetSingle(x => x.username == username);
        }
    }
}