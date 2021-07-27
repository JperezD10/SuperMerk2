using SuperMerk2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperMerk2.Business
{
    public class BitacoraBL
    {
        public List<Bitacora> GetAll()
        {
            var db = new Data.GenericDataRepository<Bitacora>();
            return db.GetAll().ToList();
        }
    }
}