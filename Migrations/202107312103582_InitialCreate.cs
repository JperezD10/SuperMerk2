namespace SuperMerk2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bitacora",
                c => new
                    {
                        idBitacora = c.Int(nullable: false, identity: true),
                        username = c.String(maxLength: 100),
                        descripcion = c.String(nullable: false),
                        fechaHora = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.idBitacora)
                .ForeignKey("dbo.Usuario", t => t.username)
                .Index(t => t.username);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        username = c.String(nullable: false, maxLength: 100),
                        password = c.String(nullable: false, maxLength: 100),
                        esAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.username);
            
            CreateTable(
                "dbo.Carrito",
                c => new
                    {
                        carritoId = c.Int(nullable: false, identity: true),
                        clienteId = c.Int(nullable: false),
                        finalizado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.carritoId)
                .ForeignKey("dbo.ClienteDatos", t => t.clienteId, cascadeDelete: true)
                .Index(t => t.clienteId);
            
            CreateTable(
                "dbo.ClienteDatos",
                c => new
                    {
                        clienteId = c.Int(nullable: false, identity: true),
                        username = c.String(maxLength: 100),
                        nombreCliente = c.String(nullable: false, maxLength: 100),
                        apellidoCliente = c.String(nullable: false, maxLength: 100),
                        numeroDoc = c.String(nullable: false, maxLength: 8),
                        mail = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.clienteId)
                .ForeignKey("dbo.Usuario", t => t.username)
                .Index(t => t.username);
            
            CreateTable(
                "dbo.ProductoDeCarrito",
                c => new
                    {
                        itemCarritoId = c.Int(nullable: false, identity: true),
                        carritoId = c.Int(nullable: false),
                        cantidadItems = c.Int(nullable: false),
                        productoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.itemCarritoId)
                .ForeignKey("dbo.Producto", t => t.productoId, cascadeDelete: true)
                .ForeignKey("dbo.Carrito", t => t.carritoId, cascadeDelete: true)
                .Index(t => t.carritoId)
                .Index(t => t.productoId);
            
            CreateTable(
                "dbo.Producto",
                c => new
                    {
                        productoId = c.Int(nullable: false, identity: true),
                        categoriaId = c.Int(nullable: false),
                        nombre = c.String(nullable: false, maxLength: 100),
                        descripcion = c.String(nullable: false, maxLength: 255),
                        imagen = c.String(),
                        stockDisponible = c.Int(nullable: false),
                        precio = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.productoId)
                .ForeignKey("dbo.Categoria", t => t.categoriaId, cascadeDelete: true)
                .Index(t => t.categoriaId);
            
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        categoriaId = c.Int(nullable: false, identity: true),
                        nombreCategoria = c.String(nullable: false, maxLength: 100),
                        descripcion = c.String(nullable: false, maxLength: 100),
                        imagen = c.String(),
                    })
                .PrimaryKey(t => t.categoriaId);
            
            CreateTable(
                "dbo.Venta",
                c => new
                    {
                        idVenta = c.Int(nullable: false, identity: true),
                        usuarioId = c.String(maxLength: 100),
                        carritoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idVenta)
                .ForeignKey("dbo.Carrito", t => t.carritoId, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.usuarioId)
                .Index(t => t.usuarioId)
                .Index(t => t.carritoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Venta", "usuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Venta", "carritoId", "dbo.Carrito");
            DropForeignKey("dbo.ProductoDeCarrito", "carritoId", "dbo.Carrito");
            DropForeignKey("dbo.ProductoDeCarrito", "productoId", "dbo.Producto");
            DropForeignKey("dbo.Producto", "categoriaId", "dbo.Categoria");
            DropForeignKey("dbo.Carrito", "clienteId", "dbo.ClienteDatos");
            DropForeignKey("dbo.ClienteDatos", "username", "dbo.Usuario");
            DropForeignKey("dbo.Bitacora", "username", "dbo.Usuario");
            DropIndex("dbo.Venta", new[] { "carritoId" });
            DropIndex("dbo.Venta", new[] { "usuarioId" });
            DropIndex("dbo.Producto", new[] { "categoriaId" });
            DropIndex("dbo.ProductoDeCarrito", new[] { "productoId" });
            DropIndex("dbo.ProductoDeCarrito", new[] { "carritoId" });
            DropIndex("dbo.ClienteDatos", new[] { "username" });
            DropIndex("dbo.Carrito", new[] { "clienteId" });
            DropIndex("dbo.Bitacora", new[] { "username" });
            DropTable("dbo.Venta");
            DropTable("dbo.Categoria");
            DropTable("dbo.Producto");
            DropTable("dbo.ProductoDeCarrito");
            DropTable("dbo.ClienteDatos");
            DropTable("dbo.Carrito");
            DropTable("dbo.Usuario");
            DropTable("dbo.Bitacora");
        }
    }
}
