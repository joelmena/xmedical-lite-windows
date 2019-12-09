using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace XMedicalLite.Models
{
    public class Triaje
    {
        public int TriajeID { get; set; }

        [Display(Name ="Color de triaje")]
        public string Color { get; set; }

        [Display(Name ="Codigo de triaje")]
        public int Codigo { get; set; }

        [Display(Name ="Descripcion")]
        public string Descripcion { get; set; }

    }
}