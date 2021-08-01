using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SuperMerk2.Models
{
    public class Carrito
    {
        [Key]
        public int carritoId { get; set; }
        [ForeignKey("clienteDatos")]
        public int clienteId { get; set; }
        public ClienteDatos clienteDatos { get; set; }
        public List<ProductoDeCarrito> listaProductosCarrito { get; set; }

        [Required]
        public bool finalizado { get; set; }
    }
}