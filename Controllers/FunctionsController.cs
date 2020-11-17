using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}