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
        public int TriajeID { get; set; }

        [Display(Name = "Motivo de consulta")]
        [DataType(DataType.MultilineText)]
        public string MotivoConsulta { get; set; }

        //Anamnesis
        [Display(Name = "Antecedentes")]
        [DataType(DataType.MultilineText)]
        public string Antecedentes { get; set; }

        [Display(Name = "Historia de enfermedad actual")]
        [DataType(DataType.MultilineText)]
        public string HistoriaEnfermedad { get; set; }

        //Signos vitales
        //public int Pulso { get; set; }

        [Display(Name = "Frecuencia cardiaca (L/Min)")]
        public int FrecuenciaCardiaca { get; set; }

        //[RegularExpression("^\d\d\d/\d(1,2)")]
        [Display(Name = "Presion arterial (Mm/Hg)")]
        public string PrecionArteriar { get; set; }

        [Display(Name = "Frecuencia respiratoria (R/Min)")]
        public int FrecuenciaRespiratoria { get; set; }

        [Display(Name = "Temperatura (Celcius)")]
        public float Temperatura { get; set; }

        [Display(Name ="Peso (Lb)")]
        public float Peso { get; set; }

        [Display(Name ="Saturacion O2 (%)")]
        public int SaturacionOxigeno { get; set; }

        [Display(Name ="Escala de Glasgow")]
        public int EscalaGlasgow { get; set; }

        [Display(Name ="Escala de dolor")]
        public int EscalaDolor { get; set; }

        //Examen general
        [Display(Name = "Examen fisico")]
        [DataType(DataType.MultilineText)]
        public string ExamenFisico { get; set; }

        [Display(Name = "Diagnostico")]
        public string Diagnostico { get; set; }

        [Display(Name = "Estudios de imagenes y analiticas")]
        [DataType(DataType.MultilineText)]
        public string Estudio { get; set; }

        [Display(Name = "Tratamientos")]
        [DataType(DataType.MultilineText)]
        public string Tratramiento { get; set; }

        [Display(Name = "Notas")]
        [DataType(DataType.MultilineText)]
        public string Nota { get; set; }

        [Display(Name = "Destino")]
        public string Destino { get; set; }

        [Display(Name = "Nombre del medico")]
        public string NombreMedico { get; set; }

        [Display(Name = "Fecha creado")]
        [DataType(DataType.DateTime)]
        public DateTime CreadoEn { get; set; }

        [Display(Name = "Fecha actualizado")]
        [DataType(DataType.DateTime)]
        public DateTime ActualizadoEn { get; set; }

        public Expediente()
        {
            this.CreadoEn = DateTime.Now;
            this.ActualizadoEn = DateTime.Now;
        }

        public virtual Paciente Paciente { get; set; }
        public virtual Triaje Triaje { get; set; }

        //Salida del paciente

    }
}
