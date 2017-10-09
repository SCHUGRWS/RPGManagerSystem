using RPGManagerSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPGManagerSystem.ViewModels
{
    public class PlayerFormViewModel
    {
        public IEnumerable<Sheet> Fichas { get; set; }
        public Player Jogador { get; set; }
        public string Title
        {
            get
            {
                if (Jogador != null && Jogador.Id != 0)
                    return "Editar Jogador";

                return "Novo Jogador";
            }
        }
    }
}