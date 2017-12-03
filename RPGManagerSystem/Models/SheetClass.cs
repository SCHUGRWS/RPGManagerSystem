using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RPGManagerSystem.Models
{
    public class SheetClass
    {
        public long Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Nome { get; set; }

        [Required]
        [StringLength(99999)]
        public string Habilidades { get; set; }
    }
}