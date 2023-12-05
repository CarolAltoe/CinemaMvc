using CinemaMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaMvc.Controllers
{
    public class FilmeController : Controller
    {

        private static IList<Filme> filmes = new List<Filme>()
        {
            new Filme(){
                Id =1,
                Titulo="meu intinho ",
                Descricao="amarelinho",
                AnoLancamento = 2001,
                Categoria = "animação",
                ClassificacaoIndicativa = "Livre",
                IdiomaId = 1
            }
        };


        // GET: Filme
        public ActionResult Index()
        {
            return View(filmes);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Filme filme)
        {
            filmes.Add(filme);
            filme.Id = filmes.Select(m => m.Id).Max() + 1;
            return RedirectToAction("Index");
        }

        public ActionResult Edit(long id)
        {
            return View(filmes.Where(m => m.Id == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Filme filme)
        {
            filmes.Remove(filmes.Where(m => m.Id == filme.Id).First());
            filmes.Add(filme);
            return RedirectToAction("Index");
        }

        public ActionResult Details(long id)
        {
            return View(filmes.Where(m => m.Id == id).First());
        }

        public ActionResult Delete(long id)
        {
            return View(filmes.Where(m => m.Id == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Filme filme)
        {
            filmes.Remove(filmes.Where(m => m.Id == filme.Id).First());
            return RedirectToAction("Index");
        }

    }
}