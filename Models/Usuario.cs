using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace XMedicalLite.Models
{
    public class Usuario
    {
        public int UsuarioID { get; set; }

        [Display(Name ="Nombre de usuario")]
        public string NombreUsuario { get; set; }

        [Display(Name ="Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Nombre")]
        public string Nombre { get; set; }

        [Display(Name ="Apellido")]
        public string Apellido { get; set; }
    }
}