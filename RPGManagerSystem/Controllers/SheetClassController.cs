using RPGManagerSystem.Models;
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
    public class SheetClassController : Controller
    {
        private ApplicationDbContext _dbContext = new ApplicationDbContext();

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }

        // GET: Classes
        public ActionResult Index()
        {
            var classIndexView = new SheetClassIndexViewModel()
            {
                Classes = _dbContext.SheetClass.ToList()
            };

            if (User.IsInRole(RoleName.Administrador))
                return View(classIndexView);

            return View("ReadOnlyIndex", classIndexView);
        }
        

        public ActionResult DetalhesClasse(int id)
        {
            SheetClass classe = _dbContext.SheetClass.Where(x => x.Id == id).FirstOrDefault();
            if (classe == null) return HttpNotFound();


            return View(classe);
        }

        [Authorize(Roles = RoleName.Administrador)]
        public ActionResult Novo()
        {
            var viewModel = new SheetClassFormViewModel()
            {
                Classe = new Models.SheetClass()
            };

            return View("FormClasse", viewModel);
        }

        [HttpPost] // só será acessada com POST
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.Administrador)]
        public ActionResult Salvar(Models.SheetClass classe)
        {
            ModelState.Remove("classe.Id");
            if (!ModelState.IsValid)
            {
                var viewModel = new SheetClassFormViewModel
                {
                    Classe = classe
                };

                return View("FormClasse", viewModel);
            }

            if (classe.Id != 0)
            {
                _dbContext.Entry(classe).State = EntityState.Modified;
            }
            else
            {
                _dbContext.SheetClass.Add(classe);
            }
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = RoleName.Administrador)]
        public ActionResult Deletar(int id)
        {
            Models.SheetClass classe = _dbContext.SheetClass.SingleOrDefault(c => c.Id == id);

            if (classe == null)
            {
                return HttpNotFound();
            }
            else
            {
                _dbContext.SheetClass.Remove(classe);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

        }

        [Authorize(Roles = RoleName.Administrador)]
        public ActionResult Editar(int id)
        {
            var classe = _dbContext.SheetClass.SingleOrDefault(c => c.Id == id);

            if (classe == null)
                return HttpNotFound();

            var viewModel = new SheetClassFormViewModel
            {
                Classe = classe
            };

            return View("FormClasse", viewModel);
        }
    }
}