using SuperMerk2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace SuperMerk2.Data.Context
{
    public class SuperMerk2Context: DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Carrito> Carritos { get; set; }
        public DbSet<ClienteDatos> DatosCliente { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Bitacora> Bitacora { get; set; }
        public DbSet<Venta> Ventas { get; set; }

        public DbSet<ProductoDeCarrito> ProductosCarrito { get; set; }
        public SuperMerk2Context() : base("SuperMercado")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}