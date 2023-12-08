using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CinemaMvc.Contexts;
using CinemaMvc.Models;

namespace CinemaMvc.Controllers
{
    public class AtuacaoController : Controller
    {
        private EFContext context = new EFContext();
        // GET: Atuacaos
        public ActionResult Index(string searchTerm)
        {
            var atuacoes = context.Atuacoes
            .OrderBy(c => c.Id)
            .AsQueryable();

            foreach (var atuacao in atuacoes)
            {

                atuacao.ator = context.Atores.Find(atuacao.AtorId);
                atuacao.filme = context.Filmes.Find(atuacao.FilmeId);
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    atuacoes = atuacoes.Where(a =>
                    atuacao.ator.Nome.Contains(searchTerm) || a.filme.Titulo.Contains(searchTerm)
                );
                }
            }

            return View(atuacoes);
        }

        public ActionResult Create()
        {
            var atuacaoViewModel = new Atuacao();


            ViewBag.Atores = new SelectList(context.Atores, "Id", "Nome");
            ViewBag.Filmes = new SelectList(context.Filmes, "Id", "Titulo");

            return View(atuacaoViewModel);

        }

        private SelectList GetDropdownList(string valueField, IEnumerable<object> source)
        {
            return new SelectList(source, valueField);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Atuacao atuacao)
        {
            context.Atuacoes.Add(atuacao);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atuacao atuacao = context.Atuacoes.Find(id);
            ViewBag.Atores = new SelectList(context.Atores, "Id", "Nome");
            ViewBag.Filmes = new SelectList(context.Filmes, "Id", "Titulo");
            if (atuacao == null)
            {
                return HttpNotFound();
            }
            return View(atuacao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Atuacao atuacao)
        {
            if (ModelState.IsValid)
            {
                context.Entry(atuacao).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(atuacao);
        }

        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atuacao atuacao = context.Atuacoes.Find(id);
            atuacao.ator = context.Atores.Find(atuacao.AtorId);
            atuacao.filme = context.Filmes.Find(atuacao.FilmeId);
            if (atuacao == null)
            {
                return HttpNotFound();
            }
            return View(atuacao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Atuacao atuacao = context.Atuacoes.Find(id);
            context.Atuacoes.Remove(atuacao);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atuacao atuacao = context.Atuacoes.Find(id);
            atuacao.ator = context.Atores.Find(atuacao.AtorId);
            atuacao.filme = context.Filmes.Find(atuacao.FilmeId);
            if (atuacao == null)
            {
                return HttpNotFound();
            }
            return View(atuacao);
        }

    }
}