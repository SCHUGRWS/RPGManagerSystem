﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RPGManagerSystem.Models
{
    public class Sheet
    {
        public long Id { get; set; }

        [Required]
        public long PlayerId { get; set; }
        public Player Player { get; set; }

        [Required]
        [StringLength(255)]
        public string Nome { get; set; }

        [Required]
        [StringLength(255)]
        public string Classe { get; set; }

        public string GameId { get; set; }
        public Game Game { get; set; }
    }
}