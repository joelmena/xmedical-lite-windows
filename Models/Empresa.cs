using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace XMedicalLite.Models
{
    public class Empresa
    {
        public int EmpresaID { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string RNC { get; set; }
        public string RutaImagen { get; set; }
    }
}