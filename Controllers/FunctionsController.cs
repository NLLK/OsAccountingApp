using OsAccountingApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OsAccountingApp1.Controllers
{
    public class FunctionsController : Controller
    {
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
            osaccountingEntities db = new osaccountingEntities();
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
    }
}