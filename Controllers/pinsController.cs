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
    public class pinsController : Controller
    {
        private osaccountingEntities db = new osaccountingEntities();

        // GET: pins
        public ActionResult Index()
        {
            var pin = db.pin.Include(p => p.MOL).Include(p => p.OS);
            return View(pin.ToList());
        }

        // GET: pins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pin pin = db.pin.Find(id);
            if (pin == null)
            {
                return HttpNotFound();
            }
            return View(pin);
        }

        // GET: pins/Create
        public ActionResult Create()
        {
            ViewBag.id_mol = new SelectList(db.MOL, "id_mol", "molname");
            ViewBag.id_os = new SelectList(db.OS, "id_os", "os_name");
            return View();
        }

        // POST: pins/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_pin,id_mol,id_os,date")] pin pin)
        {
            if (ModelState.IsValid)
            {
                db.pin.Add(pin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_mol = new SelectList(db.MOL, "id_mol", "molname", pin.id_mol);
            ViewBag.id_os = new SelectList(db.OS, "id_os", "os_name", pin.id_os);
            return View(pin);
        }

        // GET: pins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pin pin = db.pin.Find(id);
            if (pin == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_mol = new SelectList(db.MOL, "id_mol", "molname", pin.id_mol);
            ViewBag.id_os = new SelectList(db.OS, "id_os", "os_name", pin.id_os);
            return View(pin);
        }

        // POST: pins/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_pin,id_mol,id_os,date")] pin pin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_mol = new SelectList(db.MOL, "id_mol", "molname", pin.id_mol);
            ViewBag.id_os = new SelectList(db.OS, "id_os", "os_name", pin.id_os);
            return View(pin);
        }

        // GET: pins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pin pin = db.pin.Find(id);
            if (pin == null)
            {
                return HttpNotFound();
            }
            return View(pin);
        }

        // POST: pins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pin pin = db.pin.Find(id);
            db.pin.Remove(pin);
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
