using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RPGManagerSystem.Models
{
    public class Storyteller
    {
        public long Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Nome { get; set; }

        public virtual List<Game> Jogos { get; set; }

        [StringLength(255)]
        public string Apelido { get; set; }

        [Required]
        [Display(Name = "Data de Nascimento")]
        public DateTime? DataNascimento { get; set; }
    }
}