using SuperMerk2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperMerk2.Business
{
    public class CategoriaBL
    {
        //Alta de categoria
        public void altaCategoria(Categoria cat)
        {
            var db = new Data.GenericDataRepository<Categoria>();
            db.Add(cat);
        }

        //Modificacion de categoria
        public void modificarCategoria(Categoria cat)
        {
            var db = new Data.GenericDataRepository<Categoria>();
            db.Update(cat, x => x.categoriaId == cat.categoriaId);
        }

        //Borrar categoria
        public void eliminarCategoria(Categoria cat)
        {
            //Antes de eliminar la categoria, tengo que borrar los productos
            //dentro de la categoria
            List<Producto> listaProds = new ProductoBL().getProductosPorCategoria(cat.categoriaId);
            if(listaProds.Count() > 0)
            {
                var db = new Data.GenericDataRepository<Producto>();
                foreach (var item in listaProds)
                {
                    //Borro los productos
                    db.Remove(item);
                }
            }
            //Ahora borro la categoria
            var db2 = new Data.GenericDataRepository<Categoria>();
            db2.Remove(cat);
        }

        //Obtener info de una categoria
        public Categoria getDataCategoria(int idCategoria)
        {
            var db = new Data.GenericDataRepository<Categoria>();
            return db.GetSingle(x=>x.categoriaId == idCategoria);
        }
    }
}