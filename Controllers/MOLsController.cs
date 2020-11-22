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
    public class MOLsController : Controller
    {
        private osaccountingEntities db = new osaccountingEntities();

        // GET: MOLs
        public ActionResult Index()
        {
            TempData["HomePage"] = "Index";
            return View(db.MOL.ToList().OrderBy(MOL => MOL.molname));
        }

        // GET: MOLs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MOL mOL = db.MOL.Find(id);
            if (mOL == null)
            {
                return HttpNotFound();
            }
            return View(mOL);
        }
        [Authorize]
        // GET: MOLs/Create
        public ActionResult Create()
        {
            if (TempData["HomePage"].Equals("/Functions")) ViewBag.HomePage = TempData["HomePage"];
            return View();
        }

        // POST: MOLs/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_mol,molname,birthday,arivaldate")] MOL mOL)
        {
            if (ModelState.IsValid)
            {
                db.MOL.Add(mOL);
                db.SaveChanges();

                if (TempData["HomePage"].Equals("/Functions"))
                { 
                    return RedirectToAction("Functions", "Home"); }
                return RedirectToAction("Index");
            }

            return View(mOL);
        }

        // GET: MOLs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MOL mOL = db.MOL.Find(id);
            if (mOL == null)
            {
                return HttpNotFound();
            }
            return View(mOL);
        }

        // POST: MOLs/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_mol,molname,birthday,arivaldate")] MOL mOL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mOL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mOL);
        }
        [Authorize(Roles = "Admin")]
        // GET: MOLs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MOL mOL = db.MOL.Find(id);
            if (mOL == null)
            {
                return HttpNotFound();
            }
            return View(mOL);
        }

        // POST: MOLs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MOL mOL = db.MOL.Find(id);
            db.MOL.Remove(mOL);
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
