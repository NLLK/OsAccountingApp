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
    public class assigmentsController : Controller
    {

        private osaccountingEntities db = new osaccountingEntities();

        
        // GET: assigments
        public ActionResult Index()
        {
            TempData["HomePage"] = "Index";
            var assigment = db.assigment.Include(a => a.MOL).Include(a => a.unit).OrderBy(a => a.arrivaldateunit);
            return View(assigment.ToList());
        }
        [Authorize]
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
        [Authorize(Roles = "Admin")]
        // GET: assigments/Create
        public ActionResult Create()
        {
            if (TempData["HomePage"].Equals("/Functions")) ViewBag.HomePage = TempData["HomePage"];
            SelectList s = new SelectList(db.MOL, "id_mol", "molname");

            List<SelectListItem> sl = s.ToList();

            List<MOL> sd = db.MOL.ToList();//класс
            for (int i = 0; i < sl.Count; i++)
            {
                sl[i].Text = sd[i].id_mol.ToString() + ", " + sd[i].molname.ToString();//поля
            }
            ViewBag.id_mol = sl;

            SelectList ss = new SelectList(db.unit, "id_unit", "unitname");

            List<SelectListItem> ssl = ss.ToList();

            List<unit> ssd = db.unit.ToList();//класс
            for (int i = 0; i < ssl.Count; i++)
            {
                ssl[i].Text = ssd[i].id_unit.ToString() + ", " + ssd[i].unitname.ToString();//поля
            }
            ViewBag.id_unit = ssl;

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
                if (TempData["HomePage"].Equals("/Functions"))
                {
                    return RedirectToAction("Functions", "Home");
                }
                return RedirectToAction("Index");
            }

            ViewBag.id_mol = new SelectList(db.MOL, "id_mol", "molname", assigment.id_mol);
            ViewBag.id_unit = new SelectList(db.unit, "id_unit", "unitname", assigment.id_unit);
            return View(assigment);
        }
        [Authorize]
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
            SelectList s = new SelectList(db.MOL, "id_mol", "molname");

            List<SelectListItem> sl = s.ToList();

            List<MOL> sd = db.MOL.ToList();//класс
            for (int i = 0; i < sl.Count; i++)
            {
                sl[i].Text = sd[i].id_mol.ToString() + ", " + sd[i].molname.ToString();//поля
            }
            ViewBag.id_mol = sl;

            SelectList ss = new SelectList(db.unit, "id_unit", "unitname");

            List<SelectListItem> ssl = ss.ToList();

            List<unit> ssd = db.unit.ToList();//класс
            for (int i = 0; i < ssl.Count; i++)
            {
                ssl[i].Text = ssd[i].id_unit.ToString() + ", " + ssd[i].unitname.ToString();//поля
            }
            ViewBag.id_unit = ssl;
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
        [Authorize(Roles = "Admin")]
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
