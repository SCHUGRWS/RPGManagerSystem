﻿using RPGManagerSystem.Models;
using RPGManagerSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RPGManagerSystem.Controllers
{
    [Authorize]
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

            if (User.IsInRole(RoleName.Administrador))
                return View(playerIndexView);

            return View("ReadOnlyIndex", playerIndexView);
        }

        public ActionResult DetalhesJogador(int id)
        {
            Player jogador = _dbContext.Player.Include(p => p.Fichas).Where(x => x.Id == id).FirstOrDefault();
            if (jogador == null) return HttpNotFound();


            return View(jogador);
        }

        [Authorize(Roles = RoleName.Administrador)]
        public ActionResult Novo()
        {
            var viewModel = new PlayerFormViewModel()
            {
                Jogador = new Player(),
                Fichas = _dbContext.Sheet.ToList()
            };

            return View("FormJogador", viewModel);
        }

        [HttpPost] // só será acessada com POST
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.Administrador)]
        public ActionResult Salvar(Player jogador)
        {
            ModelState.Remove("jogador.Id");
            if (!ModelState.IsValid)
            {
                var viewModel = new PlayerFormViewModel
                {
                    Jogador = jogador,
                    Fichas = _dbContext.Sheet.ToList()
                };

                return View("FormJogador", viewModel);
            }

            if (jogador.Id != 0)
            {
                _dbContext.Entry(jogador).State = EntityState.Modified;
            }
            else
            {
                _dbContext.Player.Add(jogador);
            }
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = RoleName.Administrador)]
        public ActionResult Deletar(int id)
        {
            Player jogador = _dbContext.Player.SingleOrDefault(c => c.Id == id);

            if (jogador == null)
            {
                return HttpNotFound();
            }
            else
            {
                _dbContext.Player.Remove(jogador);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            
        }

        [Authorize(Roles = RoleName.Administrador)]
        public ActionResult Editar(int id)
        {
            var jogador = _dbContext.Player.SingleOrDefault(c => c.Id == id);

            if (jogador == null)
                return HttpNotFound();

            var viewModel = new PlayerFormViewModel
            {
                Jogador = jogador,
                Fichas = _dbContext.Sheet.ToList()
            };

            return View("FormJogador", viewModel);
        }
    }
}