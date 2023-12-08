using CinemaMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CinemaMvc.Contexts;
using System.Net;

namespace CinemaMvc.Controllers
{
    public class FilmeController : Controller
    {
        private EFContext context = new EFContext();

        // GET: Filme
        public ActionResult Index(string searchTerm)
        {
            var filmes = context.Filmes
                .OrderBy(c => c.Titulo)
                .AsQueryable();
            
            foreach (var filme in filmes)
            {
                filme.idioma = context.Idiomas.Find(filme.IdiomaId);
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    filmes = filmes.Where(a =>
                    a.Titulo.Contains(searchTerm)
                );
                }
            }

            return View(filmes);
        }

        public ActionResult Create()
        {
            var filmeViewModel = new Filme();

            ViewBag.Idiomas = new SelectList(context.Idiomas, "Id", "Descricao");

            return View(filmeViewModel);
        }

        private SelectList GetDropdownList(string valueField, IEnumerable<object> source)
        {
            return new SelectList(source, valueField);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Filme filme)
        {
            context.Filmes.Add(filme);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filme filme = context.Filmes.Find(id);
            ViewBag.Idiomas = new SelectList(context.Idiomas, "Id", "Descricao");
            if (filme == null)
            {
                return HttpNotFound();
            }
            return View(filme);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Filme filme)
        {
            if (ModelState.IsValid)
            {
                context.Entry(filme).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(filme);
        }

        public ActionResult Details(long id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filme filme = context.Filmes.Find(id);
            filme.idioma = context.Idiomas.Find(filme.IdiomaId);
            if (filme == null)
            {
                return HttpNotFound();
            }
            return View(filme);
        }

        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filme filme = context.Filmes.Find(id);
            filme.idioma = context.Idiomas.Find(filme.IdiomaId);
            if (filme == null)
            {
                return HttpNotFound();
            }
            return View(filme);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Filme filme = context.Filmes.Find(id);
            context.Filmes.Remove(filme);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}