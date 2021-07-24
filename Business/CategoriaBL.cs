using SuperMerk2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperMerk2.Business
{
    public class CategoriaBL
    {
        public Categoria getDataCategoria(int idCategoria)
        {
            var db = new Data.GenericDataRepository<Categoria>();
            return db.GetSingle(x=>x.categoriaId == idCategoria);
        }
    }
}