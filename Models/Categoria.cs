using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperMerk2.Models
{
    public class Categoria
    {
        [Key]
        public int categoriaId { get; set; }

        [Required(ErrorMessage = "Por favor ingrese nombre para categoria"), MinLength(1), StringLength(100)]
        [Display(Name = "Nombre de la Categoria")]
        public string nombreCategoria { get; set; }

        [Required(ErrorMessage = "Por favor ingrese una descripcion para la categoria"), MinLength(1), StringLength(100)]
        [Display(Name = "Descripcion de la Categoria")]
        public string descripcion { get; set; }

        [Display(Name = "Imagen del Producto")]
        public string imagen { get; set; }
    }
}