using RPGManagerSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPGManagerSystem.ViewModels
{
    public class StorytellerFormViewModel
    {
        public IEnumerable<Game> Jogos { get; set; }
        public Storyteller Narrador { get; set; }
        public string Title
        {
            get
            {
                if (Narrador != null && Narrador.Id != 0)
                    return "Editar Narrador";

                return "Novo Narrador";
            }
        }
    }
}