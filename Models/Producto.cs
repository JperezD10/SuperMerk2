using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SuperMerk2.Models
{
    public class Producto
    {
        [Key]
        public int productoId { get; set; }

        [ForeignKey("categoria")]
        public int categoriaId { get; set; }

        public Categoria categoria { get; set; }

        [Required(ErrorMessage= "Por favor ingrese nombre para el producto"), StringLength(100, MinimumLength = 1)]
        [Display(Name = "Nombre del Producto")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Por favor ingrese una descripcion"), StringLength(255, MinimumLength = 1)]
        [Display(Name = "Descripcion del Producto")]
        public string descripcion { get; set; }

        [Display(Name = "Imagen del Producto")]
        public string imagen { get; set; }

        [Required(ErrorMessage = "Por favor ingrese un el stock"),Display(Name = "Stock Disponible")]
        public int stockDisponible { get; set; }

        [Required(ErrorMessage = "Por favor ingrese el precio del producto"), Display(Name = "Precio")]
        [RegularExpression("^[0-9]{2}$",ErrorMessage ="Solo valores de 2 y 3 cifras")]
        [DataType(DataType.Currency)]
        public double precio { get; set; }
    }
}