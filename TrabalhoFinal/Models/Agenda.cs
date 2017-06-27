using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoFinal.Models
{
    public class Agenda
    {
        [Key]
        public int IdAgenda { get; set; }

        [Required]
        [Display(Name = "Data Início")]
        public DateTime DataHoraInicio { get; set; }

        [Required]
        [Display(Name = "Data Fim")]
        public DateTime DataHoraFim { get; set; }

        [Required]
        [Display(Name = "Médico")]
        public Medico Medico { get; set; }

    }
}
