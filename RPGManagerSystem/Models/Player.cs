using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGManagerSystem.Models
{
    public class Player
    {
        public long Id { get; set; }

        [Required]
        public string Nome { get; set; }
        
        public virtual List<Sheet> Fichas { get; set; }

        public string Apelido { get; set; }

    }
}
