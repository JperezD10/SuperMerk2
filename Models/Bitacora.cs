using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SuperMerk2.Models
{
    public class Bitacora
    {
        [Key]
        public int idBitacora { get; set; }
        [ForeignKey("usuario")]
        [StringLength(100, MinimumLength = 1)]
        public string username { get; set; }
        public Usuario usuario { get; set; }

        [Required]
        public string descripcion { get; set; }
        [Required]
        public DateTime fechaHora { get; set; }

        public Bitacora(Usuario user, string evento)
        {
            username = user.username;
            usuario = user;
            descripcion = evento;
            fechaHora = DateTime.Now;
        }
    }
}