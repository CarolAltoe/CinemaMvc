using CinemaMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaMvc.Controllers
{
    public class AtorController : Controller
    {
        private static IList<Ator> atores = new List<Ator>()
        {
            new Ator(){
                Id =1,
                Nome="maria",
                Sobrenome="linda"
            }
        };


        // GET: Ator
        public ActionResult Index()
        {
            return View(atores);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ator ator)
        {
            atores.Add(ator);
            ator.Id = atores.Select(m => m.Id).Max() + 1;
            return RedirectToAction("Index");
        }

        public ActionResult Edit(long id)
        {
            return View(atores.Where(m => m.Id == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ator ator)
        {
            atores.Remove(atores.Where(m => m.Id == ator.Id).First());
            atores.Add(ator);
            return RedirectToAction("Index");
        }

        public ActionResult Details(long id)
        {
            return View(atores.Where(m => m.Id == id).First());
        }

        public ActionResult Delete(long id)
        {
            return View(atores.Where(m => m.Id == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Ator ator)
        {
            atores.Remove(atores.Where(m => m.Id == ator.Id).First());
            return RedirectToAction("Index");
        }





    }
}