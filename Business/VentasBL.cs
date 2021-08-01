using SuperMerk2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperMerk2.Business
{
    class ItemEqualityComparer : IEqualityComparer<ProductoDeCarrito>
    {
        public bool Equals(ProductoDeCarrito x, ProductoDeCarrito y)
        {
            return x.productoId == y.productoId;
        }

        public int GetHashCode(ProductoDeCarrito obj)
        {
            return obj.productoId.GetHashCode();
        }
    }

    public class VentasBL
    {
        //Paso carrito como venta
        public void cierroCarrito(Carrito car)
        {
            car.finalizado = true;
            var db = new Data.GenericDataRepository<Carrito>();
            db.Update(car, x => x.carritoId == car.carritoId);
        }

        //Genero venta
        public void registrarVenta(Carrito carrito)
        {
            Venta venta = new Venta();
            venta.carritoId = carrito.carritoId;
            venta.usuarioId = carrito.clienteDatos.username;
            var db = new Data.GenericDataRepository<Venta>();
            db.Add(venta);
        }

        public bool SuficienteStock(Carrito carrito)
        {
            //Separo productos distintos
            List<ProductoDeCarrito> listaProdsSeparados = carrito.listaProductosCarrito.Distinct(new ItemEqualityComparer()).ToList();
            //Por cada producto diferente, me fijo si excede el stock del 
            foreach (var item in listaProdsSeparados)
            {
                ProductoBL bl = new ProductoBL();
                bool Habilitado = bl.getDataProducto(item.productoId).Habilitado;
                int cantidadEnLista = carrito.listaProductosCarrito.Where(x => x.productoId == item.productoId).Count();
                if(cantidadEnLista > item.producto.stockDisponible || !Habilitado)
                {
                    return false;
                }
            }
            return true;
        }

        public void Checkout(Carrito carrito)
        {
            ProductoBL prodBL = new ProductoBL();
            //Primero actualizo el estado del carrito
            cierroCarrito(carrito);
            //Separo productos distintos para minimizar viajes a DB
            List<ProductoDeCarrito> listaProdsSeparados = carrito.listaProductosCarrito.Distinct(new ItemEqualityComparer()).ToList();
            //Por cada producto diferente, me fijo que cantidad hay y actualizo el producto
            foreach (var item in listaProdsSeparados)
            {
                int cantidadEnLista = carrito.listaProductosCarrito.Where(x => x.productoId == item.productoId).Count();
                Producto prodAModif = item.producto;
                prodAModif.stockDisponible -= cantidadEnLista;
                prodBL.modificarProducto(prodAModif);
            }
            //Con todo modificado, genero la venta
            registrarVenta(carrito);
        }
    }
}