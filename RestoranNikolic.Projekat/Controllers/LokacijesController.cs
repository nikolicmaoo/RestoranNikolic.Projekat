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
    public class LokacijesController : Controller
    {
        private Model1 db = new Model1();

        // GET: Lokacijes
       
            public ActionResult Index(string unetalokacija, int page = 1)
            {
                var Model = db.Lokacije_set.Where(s => unetalokacija == null || s.Mesto.Contains(unetalokacija)).OrderBy(s => s.Mesto).ToList().ToPagedList(page, 3);
                return View(Model);
            }

        // GET: Lokacijes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lokacije lokacije = db.Lokacije_set.Find(id);
            if (lokacije == null)
            {
                return HttpNotFound();
            }
            return View(lokacije);
        }

        // GET: Lokacijes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lokacijes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LokacijeID,ZakazivanjeID,Mesto,BrojTelefona")] Lokacije lokacije)
        {
            if (ModelState.IsValid)
            {
                db.Lokacije_set.Add(lokacije);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lokacije);
        }

        // GET: Lokacijes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lokacije lokacije = db.Lokacije_set.Find(id);
            if (lokacije == null)
            {
                return HttpNotFound();
            }
            return View(lokacije);
        }

        // POST: Lokacijes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LokacijeID,ZakazivanjeID,Mesto,BrojTelefona")] Lokacije lokacije)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lokacije).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lokacije);
        }

        // GET: Lokacijes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lokacije lokacije = db.Lokacije_set.Find(id);
            if (lokacije == null)
            {
                return HttpNotFound();
            }
            return View(lokacije);
        }

        // POST: Lokacijes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lokacije lokacije = db.Lokacije_set.Find(id);
            db.Lokacije_set.Remove(lokacije);
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
