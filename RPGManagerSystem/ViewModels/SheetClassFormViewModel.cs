using RPGManagerSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPGManagerSystem.ViewModels
{
    public class SheetClassFormViewModel
    {
        public SheetClass Classe { get; set; }
        public string Title
        {
            get
            {
                if (Classe != null && Classe.Id != 0)
                    return "Editar Classe";

                return "Nova Classe";
            }
        }
    }
}