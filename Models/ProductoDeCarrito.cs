using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SuperMerk2.Models
{
    public class ProductoDeCarrito
    {
        [Key]
        public int itemCarritoId { get; set; }

        public int carritoId { get; set; }

        public int cantidadItems { get; set; }

        [ForeignKey("producto")]
        public int productoId { get; set; }
        public Producto producto { get; set; }

    }
}