using RestoranNikolic.Projekat.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestoranNikolic.Projekat.Controllers
{
    public class LokacijeController : Controller
    {
        private Model1 db = new Model1();
        public ActionResult Index()
        {
            return View(db.Lokacije_set.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LokacijeID, ZakazivanjeID, Mesto, BrojTelefona")] Lokacije lokacije)
        {
            if (ModelState.IsValid)
            {
                db.Lokacije_set.Add(lokacije);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lokacije);
        }
        public ActionResult Edit(int id)
        {
            Lokacije lokacije = db.Lokacije_set.Find(id);
            return View(lokacije);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LokacijeID, ZakazivanjeID, Mesto, BrojTelefona")] Lokacije lokacije)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lokacije).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lokacije);
        }
        public ActionResult Delete(int id)
        {
            Lokacije lokacije= db.Lokacije_set.Find(id);
            return View(lokacije) ;
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lokacije lokacije= db.Lokacije_set.Find(id);
            db.Lokacije_set.Remove(lokacije) ;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}