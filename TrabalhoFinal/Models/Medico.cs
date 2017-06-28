using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoFinal.Models
{
    public class Medico
    {
        [Key]
        public int IdMedico { get; set; }

        [Required]
        [Display(Name = "Nome do Médico")]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Especialidade")]
        public int IdEspecialidade { get; set; }

        public Especialidade Especialidade { get; set; }
    }
}
