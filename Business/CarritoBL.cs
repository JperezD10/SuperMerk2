using SuperMerk2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperMerk2.Business
{
    public class CarritoBL
    {
        //Trae info superficial del carrito
        public Carrito getDataCarrito(int idCarrito)
        {
            var db = new Data.GenericDataRepository<Carrito>();
            return db.GetSingle(x=>x.carritoId == idCarrito);
        }

        //Trae info completa del carrito
        public Carrito getDataCarritoFull(int idCarrito)
        {
            var db = new Data.GenericDataRepository<Carrito>();
            //Traigo info del carrito en cuestion
            Carrito carrito = db.GetSingle(x => x.carritoId == idCarrito);
            //Con esto, busco los productos asociados al carrito
            ProductoCarritoBL prodCarrBL = new ProductoCarritoBL();
            List<ProductoDeCarrito> listaProds = prodCarrBL.getProductosCarrito(idCarrito);
            //Por cada item, busco su info
            if(listaProds.Count() > 0)
            {
                ProductoBL prodBL = new ProductoBL();
                foreach (var item in listaProds)
                {
                    item.producto = prodBL.getDataProducto(item.productoId);
                }

                //Cargo lista al carrito
                carrito.listaProductosCarrito = listaProds;

                //Datos del cliente

            }
            return carrito;
        }

        //Crear carrito vacio
        public Carrito crearCarrito(Carrito car)
        {
            var db = new Data.GenericDataRepository<Carrito>();
            db.Add(car);
            return null;
        }


        //Agrega item al carrito
        public Carrito agregarItemCarrito(int idCarrito, int idProducto)
        {
            //Busco el producto
            Producto prod = new ProductoBL().getDataProducto(idProducto);
            //Creo el objeto ProductodeCarrito para agregarlo al carrito
            ProductoDeCarrito proCarrito = new ProductoDeCarrito();
            proCarrito.cantidadItems = 1;
            proCarrito.carritoId = idCarrito;
            proCarrito.productoId = prod.productoId;
            //Lo registro en EF
            new ProductoCarritoBL().agregarProdACarrito(proCarrito);
            //Busco el carrito actualizado
            Carrito carrito = getDataCarrito(idCarrito);
            carrito.listaProductosCarrito = new ProductoCarritoBL().getProductosCarritoFull(carrito.carritoId);
            return carrito;
        }

        //Borrar item del carrito
        public Carrito borrarItemCarrito(int idCarrito, int idProductodeCarrito)
        {
            //Creo el objeto ProductodeCarrito para agregarlo al carrito
            ProductoDeCarrito proCarrito = new ProductoCarritoBL().getDataProductoCarrito(idProductodeCarrito);
            proCarrito.carritoId = idCarrito;
            //Lo registro en EF
            new ProductoCarritoBL().borrarProdACarrito(proCarrito);
            //Busco el carrito actualizado
            Carrito carrito = getDataCarrito(idCarrito);
            carrito.listaProductosCarrito = new ProductoCarritoBL().getProductosCarritoFull(carrito.carritoId);
            return carrito;
        }

        //Actualizar item del carrito
        public Carrito ActualizarItemCarrito(int idCarrito, int idProductodeCarrito, int cantidad)
        {
            //Busco el producto
            Producto prod = new ProductoBL().getDataProducto(idProductodeCarrito);
            //Creo el objeto ProductodeCarrito para agregarlo al carrito
            ProductoDeCarrito proCarrito = new ProductoCarritoBL().getDataProductoCarrito(idProductodeCarrito);
            proCarrito.producto = prod;
            proCarrito.productoId = prod.productoId;
            proCarrito.carritoId = idCarrito;
            //Lo registro en EF
            new ProductoCarritoBL().borrarProdACarrito(proCarrito);
            //Busco el carrito actualizado
            Carrito carrito = getDataCarrito(idCarrito);
            carrito.listaProductosCarrito = new ProductoCarritoBL().getProductosCarritoFull(carrito.carritoId);
            return carrito;
        }

        public Carrito TraerCarritoCliente(ClienteDatos client)
        {
            var db = new Data.GenericDataRepository<Carrito>();
            Carrito car = db.GetList(x => x.clienteDatos.clienteId == client.clienteId).First();
            return car;
        }
    }
}