using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoFinal.Models
{
    public class Paciente
    {
        [Key]
        public int IdPaciente { get; set; }

        [Required]
        [Display(Name = "Nome do Paciente")]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Emais")]
        [StringLength(150)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Telefone")]
        public int Telefone { get; set; }
    }
}
