using RPGManagerSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RPGManagerSystem.Controllers
{
    public class JogadoresController : Controller
    {
        // GET: Jogadores
        public ActionResult Index()
        {
            var jogador = new JogadoresModel() { Nome = "Richard Wilhian Schug" };
            return View(jogador);
        }
    }
}