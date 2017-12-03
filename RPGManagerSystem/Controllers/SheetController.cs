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
    public class SheetController : Controller
    {
        private ApplicationDbContext _dbContext = new ApplicationDbContext();

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }

        // GET: Sheet
        public ActionResult Index()
        {
            var sheetIndexView = new SheetIndexViewModel()
            {
                Fichas = _dbContext.Sheet.Include(c => c.SheetClass).ToList()
            };

            return View(sheetIndexView);
        }

        public ActionResult DetalhesFicha(int id)
        {
            Sheet ficha = _dbContext.Sheet.Include(p => p.Player).Include(s => s.SheetClass).Where(x => x.Id == id).FirstOrDefault();
            if (ficha==null) return HttpNotFound();

            return View(ficha);
        }


        public ActionResult Novo()
        {
            var viewModel = new SheetFormViewModel() {
                Ficha = new Sheet(),
                Jogadores = _dbContext.Player.ToList(),
                Classes = _dbContext.SheetClass.ToList()
            };

            return View("FormFicha", viewModel);
        }

        [HttpPost] // só será acessada com POST
        [ValidateAntiForgeryToken]
        public ActionResult Salvar(Sheet ficha)
        {
            ModelState.Remove("sheet.Id");
            if (!ModelState.IsValid)
            {
                var viewModel = new SheetFormViewModel
                {
                    Ficha = ficha,
                    Jogadores = _dbContext.Player.ToList(),
                    Classes = _dbContext.SheetClass.ToList()
                };

                return View("FormFicha", viewModel);
            }

            if (ficha.Id != 0)
            {
                _dbContext.Entry(ficha).State = EntityState.Modified;
            }
            else
            {
                _dbContext.Sheet.Add(ficha);
            }
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Deletar(int id)
        {
            Sheet ficha = _dbContext.Sheet.SingleOrDefault(c => c.Id == id);

            if (ficha == null)
            {
                return HttpNotFound();
            }
            else
            {
                _dbContext.Sheet.Remove(ficha);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

        }

        public ActionResult Editar(int id)
        {
            var ficha = _dbContext.Sheet.SingleOrDefault(c => c.Id == id);

            if (ficha == null)
                return HttpNotFound();

            var viewModel = new SheetFormViewModel
            {
                Ficha = ficha,
                Jogadores = _dbContext.Player.ToList(),
                Classes = _dbContext.SheetClass.ToList()
            };

            return View("FormFicha", viewModel);
        }
    }
}