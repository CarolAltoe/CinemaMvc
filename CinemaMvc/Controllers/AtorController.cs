using CinemaMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using CinemaMvc.Contexts;

namespace CinemaMvc.Controllers
{
    public class AtorController : Controller
    {
        private EFContext context = new EFContext();

        // GET: Ator
        public ActionResult Index()
        {
            return View(context.Atores.OrderBy(c => c.Nome));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ator ator)
        {
            context.Atores.Add(ator);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(long id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ator categoria = context.Atores.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ator ator)
        {
            if (ModelState.IsValid)
            {
                context.Entry(ator).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ator);
        }

        public ActionResult Details(long id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ator ator = context.Atores.Find(id);
            if (ator == null)
            {
                return HttpNotFound();
            }
            return View(ator);
        }

        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ator ator = context.Atores.Find(id);
            if (ator == null)
            {
                return HttpNotFound();
            }
            return View(ator);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Ator ator = context.Atores.Find(id);
            context.Atores.Remove(ator);
            context.SaveChanges();
            return RedirectToAction("Index");
        }





    }
}