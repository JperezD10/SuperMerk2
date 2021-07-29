using SuperMerk2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperMerk2.Business
{
    public class BitacoraBL
    {
        public List<Bitacora> traerBitacoraCompleta()
        {
            var db = new Data.GenericDataRepository<Bitacora>();
            return db.GetAll().ToList();
        }

        public List<Bitacora> traerBitacoraUsuario(string user)
        {
            var db = new Data.GenericDataRepository<Bitacora>();
            return db.GetList(x=> x.username == user).ToList();
        }

        public void registrarEvento(Usuario user, string evento)
        {
            var db = new Data.GenericDataRepository<Bitacora>();
            Bitacora eventoAGuardar = new Bitacora(user, evento);
            db.Add(eventoAGuardar);
        }
    }
}