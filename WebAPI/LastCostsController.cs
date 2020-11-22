using OsAccountingApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace OsAccountingApp1.WebAPI
{
    public class LastCostsController : ApiController
    {
        private osaccountingEntities db = new osaccountingEntities();
        // GET api/lastcosts/5
        public string Get(int id)
        {
            string wearrateString = db.OS.Find(id).wearrate.Replace(".", ",");
            double wr = Convert.ToDouble(wearrateString);

            var costs = db.cost.Where(c => c.id_os == id).OrderBy(c => c.costchangedate);
            List<cost> lclist = costs.ToList();
            int count = lclist.Count;
            string lc = "";
            int lcint = 0;
            if (count == 0)
            {
                lc = "не существует";
                lcint = 0;
            }
            else
            {
                lcint = lclist[count - 1].cost1;
                lc = lcint.ToString();
            }
            string json = JsonConvert.SerializeObject(new request { wearrate = wr, lastCost = lc, recCost = (1-wr) *lcint });
            return json;

        }
    }
    [Serializable]
    public class request
    {
        public double wearrate { get; set; }
        public string lastCost { get; set; }
        public double recCost { get; set; }
    }
}
