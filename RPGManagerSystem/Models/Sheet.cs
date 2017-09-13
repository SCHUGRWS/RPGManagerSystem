using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RPGManagerSystem.Models
{
    public class Sheet
    {
        public long Id { get; set; }

        public long PlayerId { get; set; }
        public Player Player { get; set; }

    }
}