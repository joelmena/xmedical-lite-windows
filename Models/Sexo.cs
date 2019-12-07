using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace XMedicalLite.Models
{
    public class Sexo
    {
        public int SexoID { get; set; }

        [Display(Name ="Sexo")]
        public string Descripcion { get; set; }
    }
}