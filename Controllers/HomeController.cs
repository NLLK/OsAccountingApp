using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OsAccountingApp1.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Functions()
        { 
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Tables()
        {
            return View();
        }
    }
}