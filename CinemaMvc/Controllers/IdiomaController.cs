using CinemaMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaMvc.Controllers
{
    public class IdiomaController : Controller
    {
        private static IList<Idioma> idiomas = new List<Idioma>()
        {
            new Idioma(){
                Id =1,
                Descricao="chuchuuuu"
            },
            new Idioma(){
                Id = 2,
                Descricao="chucafk,lkgwshuuuu"
            },
        };


        // GET: Idioma
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Idioma idioma)
        {
            idiomas.Add(idioma);
            idioma.Id = idiomas.Select(m => m.Id).Max() + 1;
            return RedirectToAction("Index");
        }

        public ActionResult Edit(long id)
        {
            return View(idiomas.Where(m => m.Id == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Idioma idioma)
        {
            idiomas.Remove(idiomas.Where(m => m.Id == idioma.Id).First());
            idiomas.Add(idioma);
            return RedirectToAction("Index");
        }

        public ActionResult Details(long id)
        {
            return View(idiomas.Where(m => m.Id == id).First());
        }

        public ActionResult Delete(long id)
        {
            return View(idiomas.Where(m => m.Id == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Idioma idioma)
        {
            idiomas.Remove(idiomas.Where(m => m.Id == idioma.Id).First());
            return RedirectToAction("Index");
        }




    }
}