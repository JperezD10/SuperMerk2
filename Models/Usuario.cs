using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperMerk2.Models
{
    public class Usuario
    {
        [Key]
        [Required(ErrorMessage = "Por favor ingrese nombre de usuario"), StringLength(100, MinimumLength = 1)]
        [Display(Name = "Nombre de Usuario")]
        public string username { get; set; }

        [Required(ErrorMessage = "Por favor ingrese la contraseña"), StringLength(100, MinimumLength = 1)]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        public bool esAdmin { get; set; }
    }
}