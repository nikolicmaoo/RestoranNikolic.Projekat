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
    public class MenisController : Controller
    {
        private Model1 db = new Model1();

        // GET: Menis
        public ActionResult Index(string unetacena, int page = 1)
        {
            var Model = db.Meni_set.Where(s => unetacena == null || s.Cena.Contains(unetacena)).OrderBy(s => s.Cena).ToList().ToPagedList(page, 10);
            return View(Model);

        }

        // GET: Menis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meni meni = db.Meni_set.Find(id);
            if (meni == null)
            {
                return HttpNotFound();
            }
            return View(meni);
        }

        // GET: Menis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Menis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MeniID,RestoranID,Pasta,Pizza,Rostilj,Alkohol,Kafa,BezalkoholnaPica,Cena")] Meni meni)
        {
            if (ModelState.IsValid)
            {
                db.Meni_set.Add(meni);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(meni);
        }

        // GET: Menis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meni meni = db.Meni_set.Find(id);
            if (meni == null)
            {
                return HttpNotFound();
            }
            return View(meni);
        }

        // POST: Menis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MeniID,RestoranID,Pasta,Pizza,Rostilj,Alkohol,Kafa,BezalkoholnaPica,Cena")] Meni meni)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meni).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(meni);
        }

        // GET: Menis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meni meni = db.Meni_set.Find(id);
            if (meni == null)
            {
                return HttpNotFound();
            }
            return View(meni);
        }

        // POST: Menis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Meni meni = db.Meni_set.Find(id);
            db.Meni_set.Remove(meni);
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
