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

        [Display(Name = "Aseguradora")]
        public string Aseguradora { get; set; }

        [Display(Name = "Numero de NSS/Poliza")]
        public string NumeroNSS { get; set; }

        [Display(Name = "Motivo de consulta")]
        [DataType(DataType.MultilineText)]
        public string MotivoIngreso { get; set; }

        //Anamnesis
        [Display(Name = "Antecedentes")]
        [DataType(DataType.MultilineText)]
        public string Antecedentes { get; set; }

        [Display(Name = "Historia de enfermedad actual")]
        [DataType(DataType.MultilineText)]
        public string HistoriaEnfermedad { get; set; }

        //Signos vitales
        //public int Pulso { get; set; }

        [Display(Name = "Frecuencia cardiaca")]
        public int FrecuenciaCardiaca { get; set; }

        //[RegularExpression("^\d\d\d/\d(1,2)")]
        [Display(Name = "Presion arterial")]
        public string PrecionArteriar { get; set; }

        [Display(Name = "Frecuencia respiratoria")]
        public int FrecuenciaRespiratoria { get; set; }

        [Display(Name = "Temperatura")]
        public float Temperatura { get; set; }

        //Examen general
        [Display(Name = "Examen fisico")]
        [DataType(DataType.MultilineText)]
        public string ExamenPaciente { get; set; }

        [Display(Name = "Diagnostico")]
        public string Diagnostico { get; set; }

        [Display(Name = "Estudios de imagenes y analiticas")]
        [DataType(DataType.MultilineText)]
        public string Conducta { get; set; }

        [Display(Name = "Tratamientos")]
        [DataType(DataType.MultilineText)]
        public string Evolucion { get; set; }

        [Display(Name = "Notas")]
        [DataType(DataType.MultilineText)]
        public string Recomendacion { get; set; }

        [Display(Name = "Destino")]
        public string Destino { get; set; }

        [Display(Name = "Nombre del medico")]
        public string NombreMedico { get; set; }

        public virtual Paciente Paciente { get; set; }

        //Salida del paciente

    }
}
