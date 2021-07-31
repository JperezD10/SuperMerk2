using SuperMerk2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperMerk2.Business
{
    public class UsuarioBL
    {
        public bool altaUsuario(Usuario user)
        {
            bool resutlado = false;
            var usuario = this.Listar().Where(u => u.username == user.username).FirstOrDefault();
            if (usuario == null)
            {
                var db = new Data.GenericDataRepository<Usuario>();
                db.Add(user);
                resutlado = true;
            }
            else
                resutlado = false;
            return resutlado;
        }

        public void EditUsuario(Usuario usuario, string username)
        {
            var db = new Data.GenericDataRepository<Usuario>();
            db.Update(usuario, u => u.username == username);
        }
        public List<Usuario> Listar()
        {
            var db = new Data.GenericDataRepository<Usuario>();
            return db.GetAll().ToList();
        }
    }
}