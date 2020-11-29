using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OsAccountingApp1.Models;

namespace OsAccountingApp1.Controllers
{
    [Authorize]
    public class unitsController : Controller
    {
        private osaccountingEntities db = new osaccountingEntities();

        // GET: units
        public ActionResult Index()
        {
            return View(db.unit.ToList());
        }

        // GET: units/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            unit unit = db.unit.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }
        [Authorize(Roles = "Admin")]
        // GET: units/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: units/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_unit,unitname,adress")] unit unit)
        {
            if (ModelState.IsValid)
            {
                db.unit.Add(unit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(unit);
        }
        [Authorize(Roles = "Admin")]
        // GET: units/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            unit unit = db.unit.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        // POST: units/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_unit,unitname,adress")] unit unit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(unit);
        }
        [Authorize(Roles = "Admin")]
        // GET: units/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            unit unit = db.unit.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        // POST: units/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            unit unit = db.unit.Find(id);
            db.unit.Remove(unit);
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
