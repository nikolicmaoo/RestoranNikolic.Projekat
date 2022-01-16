using RestoranNikolic.Projekat.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestoranNikolic.Projekat.Controllers
{
    public class ZakazivanjeController : Controller
    {
        private Model1 db = new Model1();
        public ActionResult Index()
        {
            return View(db.Zakazivanje_set.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ZakazivanjeID, MeniID, Ime, Prezime, BrojTelefona")] Zakazivanje zakazivanje)
        {
            if (ModelState.IsValid)
            {
                db.Zakazivanje_set.Add(zakazivanje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zakazivanje);
        }
        public ActionResult Edit(int id)
        {
            Zakazivanje zakazivanje = db.Zakazivanje_set.Find(id);
            return View(zakazivanje);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ZakazivanjeID, MeniID, Ime, Prezime, BrojTelfona")] Zakazivanje zakazivanje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zakazivanje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zakazivanje);
        }
        public ActionResult Delete(int id)
        {
            Zakazivanje zakazivanje = db.Zakazivanje_set.Find(id);
            return View(zakazivanje);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zakazivanje zakazivanje = db.Zakazivanje_set.Find(id);
            db.Zakazivanje_set.Remove(zakazivanje);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}