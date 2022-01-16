using PagedList;
using RestoranNikolic.Projekat.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestoranNikolic.Projekat.Controllers
{

    public class MeniController : Controller
    {
        private Model1 db = new Model1();
        // GET: Meni
        public ActionResult Index()
        {
            return View(db.Meni_set.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MeniID, RestoranID, Pasta, Pizza, Rostilj, Alkohol, Kafa, BezalkoholnaPica, Cena")] Meni meni)
        {
            if (ModelState.IsValid)
            {
                db.Meni_set.Add(meni);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(meni);
        }
        public ActionResult Edit(int id)
        {
            Meni meni = db.Meni_set.Find(id);
            return View(meni);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MeniID, RestoranID, Pasta, Pizza, Rostilj, Alkohol, Kafa, BezalkoholnaPica, Cena")] Meni meni)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meni).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(meni);
        }
        public ActionResult Delete (int id)
        {
            Meni meni = db.Meni_set.Find(id);
            return View(meni);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Meni meni = db.Meni_set.Find(id);
            db.Meni_set.Remove(meni);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Index(int page = 1)
        {
            var model = db.Meni_set
                .ToList()
                .ToPagedList(page, 10);

            return View(model);
        }
    }
}