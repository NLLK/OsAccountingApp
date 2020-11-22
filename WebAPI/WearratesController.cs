using OsAccountingApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OsAccountingApp1
{
    public class WearratesController : ApiController
    {
        private osaccountingEntities db = new osaccountingEntities();
        // GET api/wearrates/5
        public double GetWearrate(int id)
        {
            double ans = db.OS.Find(id).wearrate;
            return ans;
        }
    }
}