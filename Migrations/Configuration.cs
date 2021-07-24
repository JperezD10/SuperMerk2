namespace SuperMerk2.Migrations
{
    using SuperMerk2.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SuperMerk2.Data.Context.SuperMerk2Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SuperMerk2.Data.Context.SuperMerk2Context context)
        {
            try
            {
                //Categorias
                Categoria carni = new Categoria() { nombreCategoria = "Carniceria", descripcion = "Los mejores cortes de la zona" };
                Categoria verdu = new Categoria() { nombreCategoria = "Verduleria", descripcion = "Frutas y Verduras para todos los gustos" };
                Categoria postre = new Categoria() { nombreCategoria = "Postres", descripcion = "Postres dulces y salados" };
                Categoria limpia = new Categoria() { nombreCategoria = "Articulos de Limpieza", descripcion = "Limpieza de muebles, electrodomesticos y mas..." };

                context.Categorias.AddOrUpdate(x => x.categoriaId,
                    carni,
                    verdu,
                    postre,
                    limpia
                );

                context.SaveChanges();

                //Productos
                var productocarne1 = new Producto() { nombre = "Bife de Chorizo", descripcion = "El mejor bife de la zona", categoria = carni, stockDisponible = 20, precio = 600 };
                var productocarne2 = new Producto() { nombre = "Vacio", descripcion = "Ideal para la parrilla", categoria = carni, stockDisponible = 15, precio = 450 };
                var productoverdu1 = new Producto() { nombre = "Pera", descripcion = "Para el verano", categoria = verdu, stockDisponible = 0, precio = 35 };
                var productopostre1 = new Producto() { nombre = "Torta de Chocolate", descripcion = "Espectacular con el cafe", categoria = postre, stockDisponible = 5, precio = 500 };

                context.Productos.AddOrUpdate(x => x.productoId,
                   productocarne1,
                   productocarne2,
                   productoverdu1,
                   productopostre1
                );

                context.SaveChanges();

                Usuario _userAdmin = new Usuario() { username = "admin", password = "admin", esAdmin = true };
                Usuario _userNormal = new Usuario() { username = "karen", password = "1234", esAdmin = false };
                //Usuario
                context.Usuarios.AddOrUpdate(x => x.username,
                    _userAdmin,
                    _userNormal
                );

                context.SaveChanges();

                //ClienteDatos

                ClienteDatos _admin = new ClienteDatos() { nombreCliente = "Norberto", apellidoCliente = "Gutierrez", mail = "norberto@mail.com", numeroDoc = "14356874", usuario = _userAdmin };
                ClienteDatos _normal = new ClienteDatos() { nombreCliente = "Karen", apellidoCliente = "Uriarte", mail = "kuriarte@mail.com", numeroDoc = "25789341", usuario = _userNormal };

                context.DatosCliente.AddOrUpdate(x => x.clienteId,
                    _admin,
                    _normal
                );

                context.SaveChanges();

            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
        }
    }
}
