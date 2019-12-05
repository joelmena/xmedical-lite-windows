using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace XMedicalLite.Models
{
    public class Expediente
    {
        public int ExpedienteID { get; set; }
        public int PacienteID { get; set; }
        public string Aseguradora { get; set; }
        public string NumeroNSS { get; set; }

        [DataType(DataType.MultilineText)]
        public string MotivoIngreso { get; set; }

        //Anamnesis
        [DataType(DataType.MultilineText)]
        public string Antecedentes { get; set; }

        //Signos vitales
        //public int Pulso { get; set; }
        public int FrecuenciaCardiaca { get; set; }

        //[RegularExpression("^\d\d\d/\d(1,2)")]
        public string PrecionArteriar { get; set; }
        public int FrecuenciaRespiratoria { get; set; }

        //Examen general
        [DataType(DataType.MultilineText)]
        public string ExamenPaciente { get; set; }
        public string Diagnostico { get; set; }
        public string Conducta { get; set; }

        [DataType(DataType.MultilineText)]
        public string Evolucion { get; set; }

        [DataType(DataType.MultilineText)]
        public string Recomendacion { get; set; }

        public virtual Paciente Paciente { get; set; }

        //Salida del paciente

    }
}
