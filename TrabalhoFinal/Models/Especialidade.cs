using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoFinal.Models
{
    public class Especialidade
    {
        [Key]
        public int IdEspecialidade { get; set; }

        [Required]
        [Display(Name = "Nome da Especialidade")]
        [StringLength(50)]
        public string Nome { get; set; }
    }
}
