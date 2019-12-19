using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XMedicalLite.Models;

namespace XMedicalLite_Windows.Models
{
    public class Reporte
    {
        public Paciente Paciente { get; set; }
        public Expediente Expediente { get; set; }
    }
}