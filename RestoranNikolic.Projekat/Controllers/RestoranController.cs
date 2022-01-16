using RestoranNikolic.Projekat.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestoranNikolic.Projekat.Controllers
{
    public class RestoranController : Controller
    {
        private Model1 db = new Model1();
        public ActionResult Index()
        {
            return View(db.Restoran_set.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RestoranID, MeniID, Naziv")] Restoran restoran)
        {
            if (ModelState.IsValid)
            {
                db.Restoran_set.Add(restoran);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restoran);
        }
        public ActionResult Edit(int id)
        {
            Restoran restoran = db.Restoran_set.Find(id);
            return View(restoran);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RestoranID, MeniID, Naziv")] Restoran restoran)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restoran).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restoran);
        }
        public ActionResult Delete(int id)
        {
            Restoran restoran = db.Restoran_set.Find(id);
            return View(restoran);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Restoran restoran = db.Restoran_set.Find(id);
            db.Restoran_set.Remove(restoran);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}