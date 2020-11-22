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
    public class costsController : Controller
    {
        private osaccountingEntities db = new osaccountingEntities();

        // GET: costs
        public ActionResult Index()
        {
            TempData["HomePage"] = "Index";
            var cost = db.cost.Include(c => c.OS);
            return View(cost.OrderBy(c => c.costchangedate).ToList());
        }

        // GET: costs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cost cost = db.cost.Find(id);
            if (cost == null)
            {
                return HttpNotFound();
            }
            return View(cost);
        }
        // GET: costs/Create
        public ActionResult Create()
        {
            if (TempData["HomePage"].Equals("/Functions")) ViewBag.HomePage = TempData["HomePage"];
            SelectList s = new SelectList(db.OS, "id_os", "os_name");

            List<SelectListItem> sl = s.ToList();

            List<OS> sd = db.OS.ToList();//класс
            for (int i = 0; i < sl.Count; i++)
            {
                sl[i].Text = sd[i].id_os.ToString() + ", " + sd[i].os_name.ToString();//поля
            }
            ViewBag.id_os = sl;
            return View();
        }

        // POST: costs/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_cost,id_os,cost1,costchangedate")] cost cost)
        {
            if (ModelState.IsValid)
            {
                db.cost.Add(cost);
                db.SaveChanges();
                if (TempData["HomePage"].Equals("/Functions"))
                {
                    return RedirectToAction("Functions", "Home");
                }
                return RedirectToAction("Index");
            }

            SelectList s = new SelectList(db.OS, "id_os", "os_name");

            List<SelectListItem> sl = s.ToList();

            List<OS> sd = db.OS.ToList();//класс
            for (int i = 0; i < sl.Count; i++)
            {
                sl[i].Text = sd[i].id_os.ToString() + ", " + sd[i].os_name.ToString();//поля
            }
            ViewBag.id_os = sl;
            return View(cost);
        }

        // GET: costs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cost cost = db.cost.Find(id);
            if (cost == null)
            {
                return HttpNotFound();
            }

            SelectList s = new SelectList(db.OS, "id_os", "os_name", cost.id_os);

            List<SelectListItem> sl = s.ToList();

            List<OS> sd = db.OS.ToList();//класс
            for (int i = 0; i < sl.Count; i++)
            {
                sl[i].Text = sd[i].id_os.ToString() + ", " + sd[i].os_name.ToString();//поля
            }
            ViewBag.id_os = sl;

            return View(cost);
        }

        // POST: costs/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_cost,id_os,cost1,costchangedate")] cost cost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_os = new SelectList(db.OS, "id_os", "os_name", cost.id_os);
            return View(cost);
        }
        [Authorize(Roles = "Admin")]
        // GET: costs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cost cost = db.cost.Find(id);
            if (cost == null)
            {
                return HttpNotFound();
            }
            return View(cost);
        }

        // POST: costs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cost cost = db.cost.Find(id);
            db.cost.Remove(cost);
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
