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
    public class FunctionsController : Controller
    {
        private osaccountingEntities db = new osaccountingEntities();
        // GET: Functions
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddMOL()
        {
            TempData["HomePage"] = "/Functions";
            return RedirectToAction("Create", "MOls");
        }
        public ActionResult AssignMOL()
        {
            TempData["HomePage"] = "/Functions";
            return RedirectToAction("Create", "assigments");
        }
        public ActionResult AddOS()
        {
            TempData["HomePage"] = "/Functions";
            return RedirectToAction("Create", "OS");
        }
        public ActionResult PinMOL()
        {
            TempData["HomePage"] = "/Functions";
            return RedirectToAction("Create", "Pins");
        }
        public ActionResult CostChange()
        {
            //TODO: добавить предыдущую цену
            TempData["HomePage"] = "/Functions";
            return RedirectToAction("Create", "costs");
        }
        public ActionResult OScard()
        {

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
        public ActionResult ReportOSIndex()
        {
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
        public ActionResult ReportOSid(int? id)
        {
            List<cost> cost = db.cost.Where(c => c.id_os == id).OrderBy(c => c.costchangedate).ToList();

            SelectList s = new SelectList(db.OS, "id_os", "os_name");

            List<SelectListItem> sl = s.ToList();

            List<OS> sd = db.OS.ToList();//класс
            for (int i = 0; i < sl.Count; i++)
            { 
                sl[i].Text = sd[i].id_os.ToString() + ", " + sd[i].os_name.ToString();//поля
            }
            ViewBag.id_os = sl;

            OS oS = db.OS.Find(id);
            ViewBag.os_name = oS.os_name;
            return View(cost);
        }
        public ActionResult ReportWorkload()
        {
            SelectList s = new SelectList(db.MOL, "id_mol", "molname");

            List<SelectListItem> sl = s.ToList();

            List<MOL> sd = db.MOL.ToList();//класс
            for (int i = 0; i < sl.Count; i++)
            {
                sl[i].Text = sd[i].id_mol.ToString() + ", " + sd[i].molname.ToString();//поля
            }
            ViewBag.id_mol = sl;

            List<assigment> assignentBasicList = db.assigment.OrderBy(a => a.id_mol).ToList();
            List<assigment> sortedList = new List<assigment>();

            int count = 0;
            foreach (assigment assigm in assignentBasicList)
            {
                if (count == 0)
                {
                    sortedList.Add(assigm);
                    count++;
                    continue;
                }

                if (assignentBasicList[count - 1].id_mol == assigm.id_mol)
                {
                    if (assignentBasicList[count - 1].arrivaldateunit < assigm.arrivaldateunit)
                    {
                        sortedList[count - 1] = assigm;
                    }
                    else continue;
                }
                else
                {
                    sortedList.Add(assigm);
                    count++;
                }
            }

            List<WorkLoadReportModel> mollist = new List<WorkLoadReportModel>();
            foreach (assigment el in sortedList)
            {
                mollist.Add(new WorkLoadReportModel { molname = el.MOL.molname,
                    arrivaldateunit = el.arrivaldateunit, birthday = el.MOL.birthday, unit = el.unit.unitname });
            }

            return View(mollist.OrderBy(m => m.unit));
        }
    }
}