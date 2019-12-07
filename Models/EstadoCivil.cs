using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace XMedicalLite.Models
{
    public class EstadoCivil
    {
        public int EstadoCivilID { get; set; }

        [Display(Name ="Estado Civil")]
        public string Descripcion { get; set; }
    }
}