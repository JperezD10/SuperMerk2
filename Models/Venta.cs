using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SuperMerk2.Models
{
    public class Venta
    {
        [Key]
        public int idVenta { get; set; }

        [ForeignKey("usuario")]
        public string usuarioId { get; set; }
        public Usuario usuario { get; set; }
        [ForeignKey("carrito")]
        public int carritoId { get; set; }
        public Carrito carrito { get; set; }
    }
}