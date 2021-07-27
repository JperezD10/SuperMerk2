using SuperMerk2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperMerk2.Business
{
    public class UsuarioBL
    {
        public void altaUsuario(Usuario user)
        {
            var db = new Data.GenericDataRepository<Usuario>();
            db.Add(user);
        }

        public List<Usuario> Listar()
        {
            var db = new Data.GenericDataRepository<Usuario>();
            return db.GetAll().ToList();
        }
    }
}