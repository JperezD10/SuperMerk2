using SuperMerk2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperMerk2.Business
{
    public class ProductoCarritoBL
    {
        //Trae infor basica de un producto asociado a un carrito
        public ProductoDeCarrito getDataProductoCarrito(int idProdCarrito)
        {
            var db = new Data.GenericDataRepository<ProductoDeCarrito>();
            return db.GetSingle(x=>x.itemCarritoId == idProdCarrito);
        }

        //Trae productos asociados a un carrito sin detallar
        public List<ProductoDeCarrito> getProductosCarrito(int idCarrito)
        {
            var db = new Data.GenericDataRepository<ProductoDeCarrito>();
            return db.GetAll().Where(x => x.carritoId == idCarrito).ToList();
        }

        //Trae productos asociados a un carrito detallado
        public List<ProductoDeCarrito> getProductosCarritoFull(int idCarrito)
        {
            var db = new Data.GenericDataRepository<ProductoDeCarrito>();
            List<ProductoDeCarrito> listaProds = db.GetAll().Where(x => x.carritoId == idCarrito).ToList();
            if (listaProds.Count() > 0)
            {
                ProductoBL prodBL = new ProductoBL();
                foreach (var item in listaProds)
                {
                    item.producto = prodBL.getDataProducto(item.productoId);
                }
            }
            return listaProds;
        }

        //Guardar ProductodeCarrito
        public void agregarProdACarrito(ProductoDeCarrito prod)
        {
            var db = new Data.GenericDataRepository<ProductoDeCarrito>();
            db.Add(prod);
        }

        //Borrar ProductodeCarrito
        public void borrarProdACarrito(ProductoDeCarrito prodDeCarrito)
        {
            var db = new Data.GenericDataRepository<ProductoDeCarrito>();
            db.Remove(prodDeCarrito);
        }

        //Actualizar ProductodeCarrito
        public void actualizarProdACarrito(int prodDeCarritoId, int cantidad)
        {
            //Busco el producto
            ProductoDeCarrito prod = getDataProductoCarrito(prodDeCarritoId);
            //Si la cantidad es igual, no actualizo
            if(cantidad != prod.cantidadItems)
            {
                prod.cantidadItems = cantidad;
                var db = new Data.GenericDataRepository<ProductoDeCarrito>();
                db.Update(prod, x=>x.itemCarritoId == prodDeCarritoId);
            }
        }

    }
}