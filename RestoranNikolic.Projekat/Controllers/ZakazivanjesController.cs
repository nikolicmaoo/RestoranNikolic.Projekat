using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RestoranNikolic.Projekat.Models;
using PagedList;
using PagedList.Mvc;

namespace RestoranNikolic.Projekat.Controllers
{

    public class ZakazivanjesController : Controller
    {
        private Model1 db = new Model1();

        // GET: Zakazivanjes
        public ActionResult Index(string unetbroj, int page = 1)
        {
            var Model = db.Zakazivanje_set.Where(s => unetbroj == null || s.Ime.Contains(unetbroj)).OrderBy(s => s.Ime).ToList();
            return View(Model);
        }

        // GET: Zakazivanjes/Details/5

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zakazivanje zakazivanje = db.Zakazivanje_set.Find(id);
            if (zakazivanje == null)
            {
                return HttpNotFound();
            }
            return View(zakazivanje);
        }

        // GET: Zakazivanjes/Create

        public ActionResult Create()
        {
            return View();
        }

        // POST: Zakazivanjes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ZakazivanjeID,MeniID,Ime,Prezime,BrojTelefona,Datum")] Zakazivanje zakazivanje)
        {
            if (ModelState.IsValid)
            {
                db.Zakazivanje_set.Add(zakazivanje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zakazivanje);
        }

        // GET: Zakazivanjes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zakazivanje zakazivanje = db.Zakazivanje_set.Find(id);
            if (zakazivanje == null)
            {
                return HttpNotFound();
            }
            return View(zakazivanje);
        }

        // POST: Zakazivanjes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ZakazivanjeID,MeniID,Ime,Prezime,BrojTelefona,Datum")] Zakazivanje zakazivanje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zakazivanje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zakazivanje);
        }

        // GET: Zakazivanjes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zakazivanje zakazivanje = db.Zakazivanje_set.Find(id);
            if (zakazivanje == null)
            {
                return HttpNotFound();
            }
            return View(zakazivanje);
        }

        // POST: Zakazivanjes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zakazivanje zakazivanje = db.Zakazivanje_set.Find(id);
            db.Zakazivanje_set.Remove(zakazivanje);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
