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
        public ActionResult Index()
        {
            return View(context.Atuacoes.OrderBy(c => c.Id));
        }

        public ActionResult Create()
        {
            return View();
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
            if (atuacao == null)
            {
                return HttpNotFound();
            }
            return View(atuacao);
        }

    }
}