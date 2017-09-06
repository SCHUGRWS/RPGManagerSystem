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
        private ApplicationDbContext _dbContext = new ApplicationDbContext();

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }

        // GET: Jogadores
        public ActionResult Index()
        {
            var playerIndexView = new PlayerIndexViewModel()
            {
                Jogadores = _dbContext.Player.ToList()
            };
            
            return View(playerIndexView);
        }

        public ActionResult DetalhesJogador(int id)
        {
            if (id > _dbContext.Player.Count()) return HttpNotFound();

            Player jogadorDetalhe = _dbContext.Player.Find(id);

            return View(jogadorDetalhe);
        }
    }
}