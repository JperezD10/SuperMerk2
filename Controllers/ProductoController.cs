using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperMerk2.Business;
using SuperMerk2.Models;

namespace SuperMerk2.Controllers
{
    public class ProductoController : Controller
    {
        [HttpGet]
        public ActionResult ListAllProductos()
        {
            if (Session["UserSession"] == null)
            {
                RedirectToAction("LogIn", "Login");
            }
            ProductoBL biz = new ProductoBL();
            var product = biz.getAll().Where(p => p.Habilitado == true).ToList();
            return View(product);
        }
        [HttpGet]
        public ActionResult ListProductos()
        {
            Usuario usuario = Session["UserSession"] as Usuario;
            if (usuario != null)
            {
                if (usuario.esAdmin)
                {
                    ProductoBL biz = new ProductoBL();
                    var product = biz.getAll();
                    CategoriaBL bL = new CategoriaBL();
                    foreach (var p in product)
                    {
                        p.categoria = bL.GetAll().Where(c => c.categoriaId == p.categoriaId).FirstOrDefault();
                    }
                    return View(product);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("LogIn", "Login");
            }

        }
        [HttpGet]
        public ActionResult ListProductosxCategory(int id)
        {
            if (Session["UserSession"] == null)
            {
                return RedirectToAction("LogIn", "Login");
            }
            ProductoBL biz = new ProductoBL();
            var product = biz.getProductosPorCategoria(id).Where(p =>p.Habilitado==true).ToList();
            return View("ListAllProductos", product);
        }

        [HttpGet]
        public ActionResult DetalleProducto(int id)
        {
            if (Session["UserSession"] == null)
            {
                return RedirectToAction("LogIn", "Login");
            }
            ProductoBL biz = new ProductoBL();
            var product = biz.getDataProducto(id);
            return View(product);
        }

        [HttpGet]
        public ActionResult CreateProducto()
        {
            Usuario usuario = Session["UserSession"] as Usuario;
            if (usuario != null)
            {
                if (usuario.esAdmin)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("LogIn", "Login");
            }            
        }
        [HttpPost]
        public ActionResult CreateProducto(Producto product)
        {
            if (ModelState.IsValid)
            {
                ProductoBL biz = new ProductoBL();
                product.Habilitado = true;
                biz.altaProducto(product);
                //Log Evento
                new BitacoraController().RegistrarEvento(Session["UserSession"] as Usuario, "Creo un producto");
                return RedirectToAction("ListProductos");
            }
            else
            {
                return View();
            }

        }

        [HttpGet]
        public ActionResult EditProducto(int id)
        {
            if (Session["UserSession"] == null)
            {
                return RedirectToAction("LogIn", "Login");
            }
            ProductoBL biz = new ProductoBL();
            var producto = biz.getDataProducto(id);
            return View(producto);
        }
        [HttpPost]
        public ActionResult EditProducto(Producto product)
        {
            if (ModelState.IsValid)
            { 
                ProductoBL biz = new ProductoBL();
                biz.modificarProducto(product);
                //Log Evento
                new BitacoraController().RegistrarEvento(Session["UserSession"] as Usuario, "Modifico un producto");
                return RedirectToAction("ListProductos", "Producto");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult ProductosCategoria(int id)
        {
            if (Session["UserSession"] == null)
            {
                return RedirectToAction("LogIn", "Login");
            }
            ProductoBL biz = new ProductoBL();
            var product = biz.getProductosPorCategoria(id);
            return View(product);
        }
        [HttpGet]
        public ActionResult EliminarProductos(int id)
        {
            if (Session["UserSession"] == null)
            {
                return RedirectToAction("LogIn", "Login");
            }
            ProductoBL biz = new ProductoBL();
            biz.eliminarProducto(biz.getDataProducto(id));
            //Log Evento
            new BitacoraController().RegistrarEvento(Session["UserSession"] as Usuario, "Elimino un producto");
            return RedirectToAction("ListProductos", "Producto");
        }
        [HttpGet]
        public ActionResult ReactivarProductos(int id)
        {
            if (Session["UserSession"] == null)
            {
                return RedirectToAction("LogIn", "Login");
            }
            ProductoBL biz = new ProductoBL();
            biz.ReactivarProducto(biz.getDataProducto(id));
            //Log Evento
            new BitacoraController().RegistrarEvento(Session["UserSession"] as Usuario, "Reactivo un producto");
            return RedirectToAction("ListProductos", "Producto");
        }

        [HttpGet]
        public ActionResult AddToCart(Producto product)
        {
            Carrito carritocompra;
            CarritoBL cart = new CarritoBL();
            if (Session["UserSession"] == null)
            {
                return RedirectToAction("LogIn", "Login");
            }
            if (Session["ClientSession"] == null)
            {
                return RedirectToAction("CreateClienteData", "ClienteDatos");
            }
            var user = Session["ClientSession"] as ClienteDatos;
            if(Session["Carrito"] != null)
            {
                carritocompra = Session["Carrito"] as Carrito;
                int cantidadProductoCarrito = carritocompra.listaProductosCarrito.Where(p => p.productoId == product.productoId).Count();
                if(product.stockDisponible <= cantidadProductoCarrito)
                {
                    return RedirectToAction("ListProductosxCategory","Producto", new { id = product.categoriaId });
                }
                else
                {
                    cart.agregarItemCarrito(carritocompra.carritoId, product.productoId);
                    Session["Carrito"] = cart.getDataCarritoFull(carritocompra.carritoId);
                    //Log Evento
                    new BitacoraController().RegistrarEvento(Session["UserSession"] as Usuario, "Agrego un item a su carrito");
                }

            }
            else
            {
                carritocompra = new Carrito();
                carritocompra.clienteId = user.clienteId;
                cart.crearCarrito(carritocompra);
                //Log Evento
                new BitacoraController().RegistrarEvento(Session["UserSession"] as Usuario, "Creo un carrito");
                cart.agregarItemCarrito(carritocompra.carritoId, product.productoId);
                //Log Evento
                new BitacoraController().RegistrarEvento(Session["UserSession"] as Usuario, "Agrego un producto a su carrito");
                Session["Carrito"] = cart.getDataCarritoFull(carritocompra.carritoId);
            }
            return RedirectToAction("ListProductosxCategory", "Producto", new {id =product.categoriaId});
        }
    }
}
