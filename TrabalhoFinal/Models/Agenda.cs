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
        [Display(Name = "Data Agenda")]
        [DataType(DataType.Date)]
        public DateTime DataAgenda { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Horário de entrada")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh\\:mm}")]
        public TimeSpan HorarioEntrada { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Horário de saiba")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh\\:mm}")]
        public TimeSpan HorarioSaida { get; set; }

        [Required]
        [Display(Name = "Médico")]
        public int IdMedico { get; set; }

        public Medico Medico { get; set; }

    }
}
