using SuperMerk2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperMerk2.Business
{
    public class ProductoBL
    {
        //Trae info de un producto y su categoria
        public Producto getDataProducto(int idProducto)
        {
            var db = new Data.GenericDataRepository<Producto>();
            Producto prod = db.GetSingle(x=>x.productoId == idProducto);
            //Busco info de la categoria
            CategoriaBL catBL = new CategoriaBL();
            prod.categoria = catBL.getDataCategoria(prod.categoriaId);
            return prod;
        }

        //Trae productos en base a su categoria
        public List<Producto> getProductosPorCategoria(int idCategoria)
        {
            var db = new Data.GenericDataRepository<Producto>();
            List<Producto> prod = db.GetAll(x => x.categoriaId == idCategoria).ToList();
            //Busco info de la categoria
            CategoriaBL catBL = new CategoriaBL();
            //Como todos los prods tienen la misma categoria, busco la info 1 sola vez
            Categoria categoria = catBL.getDataCategoria(idCategoria);
            foreach (var item in prod)
            {
                item.categoria = categoria;
            }
            return prod;
        }
    }
}