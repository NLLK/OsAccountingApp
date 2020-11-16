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
    [Authorize(Roles = "Admin")]
    public class OSController : Controller
    {
        private osaccountingEntities db = new osaccountingEntities();

        // GET: OS
        public ActionResult Index()
        {
            var oS = db.OS.Include(o => o.group);
            return View(oS.ToList().OrderBy(o => o.service_start));
        }

        // GET: OS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OS oS = db.OS.Find(id);
            if (oS == null)
            {
                return HttpNotFound();
            }
            return View(oS);
        }

        // GET: OS/Create
        public ActionResult Create()
        {
            SelectList s = new SelectList(db.group, "id_class", "classname");

            List<SelectListItem> sl = s.ToList();

            List<group> sd = db.group.ToList();//класс
            for (int i = 0; i < sl.Count; i++)
            {
                sl[i].Text = sd[i].id_class.ToString() + ", " + sd[i].classname.ToString();//поля
            }
            ViewBag.id_class = sl;
            return View();
        }

        // POST: OS/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_os,id_class,os_name,invertory_number,wearrate,service_start,service_time")] OS oS)
        {
            if (ModelState.IsValid)
            {
                db.OS.Add(oS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_class = new SelectList(db.group, "id_class", "classname", oS.id_class);
            return View(oS);
        }

        // GET: OS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OS oS = db.OS.Find(id);
            if (oS == null)
            {
                return HttpNotFound();
            }
            SelectList s = new SelectList(db.group, "id_class", "classname");

            List<SelectListItem> sl = s.ToList();

            List<group> sd = db.group.ToList();//класс
            for (int i = 0; i < sl.Count; i++)
            {
                sl[i].Text = sd[i].id_class.ToString() + ", " + sd[i].classname.ToString();//поля
            }
            ViewBag.id_class = sl;
            return View(oS);
        }

        // POST: OS/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_os,id_class,os_name,invertory_number,wearrate,service_start,service_time")] OS oS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_class = new SelectList(db.group, "id_class", "classname", oS.id_class);
            return View(oS);
        }

        // GET: OS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OS oS = db.OS.Find(id);
            if (oS == null)
            {
                return HttpNotFound();
            }
            return View(oS);
        }

        // POST: OS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OS oS = db.OS.Find(id);
            db.OS.Remove(oS);
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
