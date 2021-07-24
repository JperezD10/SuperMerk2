using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SuperMerk2.Models
{
    public class ClienteDatos
    {
        [Key]
        public int clienteId { get; set; }
        [ForeignKey("usuario")]
        public string username { get; set; }
        public Usuario usuario { get; set; }

        [Required(ErrorMessage = "Por favor ingrese su nombre"), StringLength(100, MinimumLength = 1)]
        [Display(Name = "Nombre")]
        public string nombreCliente { get; set; }

        [Required(ErrorMessage = "Por favor ingrese su apellido"), StringLength(100, MinimumLength = 1)]
        [Display(Name = "Apellido")]
        public string apellidoCliente { get; set; }

        [Required(ErrorMessage = "Por favor ingrese su Nro. de Documento"), StringLength(8, ErrorMessage = "El Numero de Documento no puede tener mas de 8 digitos")]
        [Display(Name = "Nro. de Documento")]
        public string numeroDoc { get; set; }

        [Required(ErrorMessage = "Por favor ingrese un mail de contacto"), StringLength(100)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Mail")]
        
        public string mail { get; set; }
    }
}