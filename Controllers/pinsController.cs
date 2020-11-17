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
    public class pinsController : Controller
    {
        private osaccountingEntities db = new osaccountingEntities();

        // GET: pins
        public ActionResult Index()
        {
            var pin = db.pin.Include(p => p.MOL).Include(p => p.OS).OrderBy(p => p.date);
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
        [Authorize(Roles = "Admin")]
        // GET: pins/Create
        public ActionResult Create()
        {
            SelectList s = new SelectList(db.MOL, "id_mol", "molname");

            List<SelectListItem> sl = s.ToList();

            List<MOL> sd = db.MOL.ToList();//класс
            for (int i = 0; i < sl.Count; i++)
            {
                sl[i].Text = sd[i].id_mol.ToString() + ", " + sd[i].molname.ToString();//поля
            }
            ViewBag.id_mol = sl;

            SelectList ss = new SelectList(db.OS, "id_os", "os_name");

            List<SelectListItem> ssl = ss.ToList();

            List<OS> ssd = db.OS.ToList();//класс
            for (int i = 0; i < ssl.Count; i++)
            {
                ssl[i].Text = ssd[i].id_os.ToString() + ", " + ssd[i].os_name.ToString();//поля
            }
            ViewBag.id_os = ssl;
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
            SelectList s = new SelectList(db.MOL, "id_mol", "molname");

            List<SelectListItem> sl = s.ToList();

            List<MOL> sd = db.MOL.ToList();//класс
            for (int i = 0; i < sl.Count; i++)
            {
                sl[i].Text = sd[i].id_mol.ToString() + ", " + sd[i].molname.ToString();//поля
            }
            ViewBag.id_mol = sl;

            SelectList ss = new SelectList(db.OS, "id_os", "os_name");

            List<SelectListItem> ssl = ss.ToList();

            List<OS> ssd = db.OS.ToList();//класс
            for (int i = 0; i < ssl.Count; i++)
            {
                ssl[i].Text = ssd[i].id_os.ToString() + ", " + ssd[i].os_name.ToString();//поля
            }
            ViewBag.id_os = ssl;
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
        [Authorize(Roles = "Admin")]
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
