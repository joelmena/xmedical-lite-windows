using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace XMedicalLite.Models
{
    public class Paciente
    {
        public int PacienteID { get; set; }

        [Display(Name ="Numero de Referencia")]
        public string Referencia { get; set; }

        [Display(Name ="Nombres")]
        public string Nombres { get; set; }

        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }

        [Display(Name = "Sexo")]
        public int SexoID { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Display(Name = "Cedula")]
        public string Cedula { get; set; }

        [Display(Name = "Estado civil")]
        public int EstadoCivilID { get; set; }

        [Display(Name = "Telefono")]
        public string Telefono { get; set; }

        [Display(Name = "Direccion")]
        public string Direccion { get; set; }

        [Display(Name = "Provincia")]
        public string Provincia { get; set; }

        [Display(Name = "Municipio")]
        public string Municipio { get; set; }

        [Display(Name = "Aseguradora")]
        public string Aseguradora { get; set; }

        [Display(Name = "Numero de NSS/Poliza")]
        public string NumeroNSS { get; set; }


        public virtual Sexo Sexo { get; set; }
        public virtual EstadoCivil EstadoCivil { get; set; }
    }
}
