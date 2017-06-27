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

        [Display(Name = "Data")]
        public DateTime DataHora { get; set; }
        
        [Display(Name = "Médico")]
        public Medico Medico { get; set; }

        [Display(Name = "Paciente")]
        public Paciente Paciente { get; set; }
    }
}
