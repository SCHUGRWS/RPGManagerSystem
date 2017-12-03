using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Linq;
using RPGManagerSystem.Models;
using RPGManagerSystem.ViewModels;

namespace RPGManagerSystem.Controllers
{
    [Authorize]
    public class StorytellerController : Controller
    {
        private ApplicationDbContext _dbContext = new ApplicationDbContext();

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }

        // GET: Storyteller
        public ActionResult Index()
        {
            var storytellerIndexView = new StorytellerIndexViewModel()
            {
                Narradores = _dbContext.Storyteller.ToList()
            };

            return View(storytellerIndexView);
        }

        public ActionResult DetalhesNarrador(int id)
        {
            Storyteller narrador = _dbContext.Storyteller.Where(x => x.Id == id).FirstOrDefault();
            if (narrador == null) return HttpNotFound();


            return View(narrador);
        }


        public ActionResult Novo()
        {
            var viewModel = new StorytellerFormViewModel(){
                Narrador = new Storyteller()
            };

            return View("FormNarrador", viewModel);
        }

        [HttpPost] // só será acessada com POST
        [ValidateAntiForgeryToken]
        public ActionResult Salvar(Storyteller narrador)
        {
            ModelState.Remove("narrador.Id");
            if (!ModelState.IsValid)
            {
                var viewModel = new StorytellerFormViewModel
                {
                    Narrador = narrador
                };

                return View("FormNarrador", viewModel);
            }

            if (narrador.Id != 0)
            {
                _dbContext.Entry(narrador).State = EntityState.Modified;
            }
            else
            {
                _dbContext.Storyteller.Add(narrador);
            }
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Deletar(int id)
        {
            Storyteller narrador = _dbContext.Storyteller.SingleOrDefault(c => c.Id == id);

            if (narrador == null)
            {
                return HttpNotFound();
            }
            else
            {
                _dbContext.Storyteller.Remove(narrador);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

        }

        public ActionResult Editar(int id)
        {
            var narrador = _dbContext.Storyteller.SingleOrDefault(c => c.Id == id);

            if (narrador == null)
                return HttpNotFound();

            var viewModel = new StorytellerFormViewModel
            {
                Narrador = narrador
            };

            return View("FormNarrador", viewModel);
        }
    }
}