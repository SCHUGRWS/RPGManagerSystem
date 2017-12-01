using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGManagerSystem.Models
{
    public class Game
    {
        public long Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Nome { get; set; }
        
        public virtual List<Sheet> Fichas { get; set; }

        [Required]
        public long StorytellerId { get; set; }
        public Storyteller Storyteller { get; set; }

        [Required]
        [StringLength(9999)]
        public string Historia { get; set; }
    }
}
