using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoFinal.Models
{
    public class Consulta
    {
        [Key]
        public int IdConsulta { get; set; }

        [Required]
        [Display(Name = "Médico")]
        public int IdMedico { get; set; }

        public Medico Medico { get; set; }

        [Display(Name = "Paciente")]
        public int IdPaciente { get; set; }

        public Paciente Paciente { get; set; }

        [Display(Name = "Data Consulta")]
        [DataType(DataType.Date)]
        public DateTime DataHora { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Horário da Consulta")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh\\:mm}")]
        public TimeSpan HorarioConsulta { get; set; }
    }
}
