using RPGManagerSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPGManagerSystem.ViewModels
{
    public class SheetFormViewModel
    {
        public IEnumerable<Player> Jogadores { get; set; }
        public IEnumerable<SheetClass> Classes { get; set; }
        public Sheet Ficha { get; set; }
        public string Title
        {
            get
            {
                if (Ficha != null && Ficha.Id != 0)
                    return "Editar Ficha";

                return "Nova Ficha";
            }
        }
    }
}