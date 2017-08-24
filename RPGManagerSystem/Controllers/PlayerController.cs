using RPGManagerSystem.Models;
using RPGManagerSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RPGManagerSystem.Controllers
{
    public class PlayerController : Controller
    {
        static List<PlayerModel> listaJogadores = new List<PlayerModel>()
        {
            new PlayerModel()
            {
                Id = 1, Nome = "Richard Wilhian Schug"
            },
            new PlayerModel()
            {
                Id = 2,
                Nome = "Teste 2"
            }
        }
        ;

        // GET: Jogadores
        public ActionResult Index()
        {
            var playerIndexView = new PlayerIndexViewModel()
            {
                Jogadores=listaJogadores
            };
            
            return View(playerIndexView);
        }

        public ActionResult DetalhesJogador(int id)
        {
            if (id > listaJogadores.Count) return HttpNotFound();

            PlayerModel jogadorDetalhe = listaJogadores.Find(jogador => jogador.Id==id);

            return View(jogadorDetalhe);
        }
    }
}