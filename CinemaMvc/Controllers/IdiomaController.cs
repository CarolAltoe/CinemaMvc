
using CinemaMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CinemaMvc.Contexts;

namespace CinemaMvc.Controllers
{
    public class IdiomaController : Controller
    {

        private EFContext context = new EFContext();
        // GET: Idioma
        [HttpGet]
        public ActionResult Index(string searchTerm)
        {
            var idiomas = context.Idiomas
                .OrderBy(c => c.Descricao)
                .AsQueryable();

            foreach (var idioma in idiomas)
            {
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    idiomas = idiomas.Where(a =>
                    a.Descricao.Contains(searchTerm)
                );
                }
            }

            return View(idiomas);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Idioma idioma)
        {
            context.Idiomas.Add(idioma);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(long id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Idioma idioma = context.Idiomas.Find(id);
            if (idioma == null)
            {
                return HttpNotFound();
            }
            return View(idioma);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Idioma idioma)
        {
            if (ModelState.IsValid)
            {
                context.Entry(idioma).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(idioma);
        }

        public ActionResult Details(long id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Idioma idioma = context.Idiomas.Find(id);
            if (idioma == null)
            {
                return HttpNotFound();
            }
            return View(idioma);
        }

        public ActionResult Delete(long id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Idioma idioma = context.Idiomas.Find(id);
            if (idioma == null)
            {
                return HttpNotFound();
            }
            return View(idioma);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long? id)
        {
            Idioma idioma = context.Idiomas.Find(id);
            context.Idiomas.Remove(idioma);
            context.SaveChanges();
            return RedirectToAction("Index");
        }




    }
}