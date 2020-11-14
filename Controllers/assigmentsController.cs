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
    public class assigmentsController : Controller
    {
        private osaccountingEntities db = new osaccountingEntities();

        // GET: assigments
        public ActionResult Index()
        {
            var assigment = db.assigment.Include(a => a.MOL).Include(a => a.unit);
            return View(assigment.ToList());
        }

        // GET: assigments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            assigment assigment = db.assigment.Find(id);
            if (assigment == null)
            {
                return HttpNotFound();
            }
            return View(assigment);
        }

        // GET: assigments/Create
        public ActionResult Create()
        {
            ViewBag.id_mol = new SelectList(db.MOL, "id_mol", "molname");
            ViewBag.id_unit = new SelectList(db.unit, "id_unit", "unitname");
            return View();
        }

        // POST: assigments/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_assignment,id_mol,id_unit,arrivaldateunit")] assigment assigment)
        {
            if (ModelState.IsValid)
            {
                db.assigment.Add(assigment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_mol = new SelectList(db.MOL, "id_mol", "molname", assigment.id_mol);
            ViewBag.id_unit = new SelectList(db.unit, "id_unit", "unitname", assigment.id_unit);
            return View(assigment);
        }

        // GET: assigments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            assigment assigment = db.assigment.Find(id);
            if (assigment == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_mol = new SelectList(db.MOL, "id_mol", "molname", assigment.id_mol);
            ViewBag.id_unit = new SelectList(db.unit, "id_unit", "unitname", assigment.id_unit);
            return View(assigment);
        }

        // POST: assigments/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_assignment,id_mol,id_unit,arrivaldateunit")] assigment assigment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assigment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_mol = new SelectList(db.MOL, "id_mol", "molname", assigment.id_mol);
            ViewBag.id_unit = new SelectList(db.unit, "id_unit", "unitname", assigment.id_unit);
            return View(assigment);
        }

        // GET: assigments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            assigment assigment = db.assigment.Find(id);
            if (assigment == null)
            {
                return HttpNotFound();
            }
            return View(assigment);
        }

        // POST: assigments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            assigment assigment = db.assigment.Find(id);
            db.assigment.Remove(assigment);
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
