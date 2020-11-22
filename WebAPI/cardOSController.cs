using Newtonsoft.Json;
using OsAccountingApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace OsAccountingApp1.WebAPI
{
    public class cardOSController : ApiController
    {
        private osaccountingEntities db = new osaccountingEntities();
        // GET api/lastcosts/5
        public string Get(int id)
        {
            //данные с апи
            LastCostsController lastCostsController = new LastCostsController();
            requestLastCost requestLastCost = JsonConvert.DeserializeObject<requestLastCost>(lastCostsController.Get(id));
            string lastcost = requestLastCost.lastCost;
            string wearrate = requestLastCost.wearrate.ToString();
            //OS
            OS oS = db.OS.Find(id);

            string os_name = oS.os_name;
            string class1 = oS.id_class.ToString() + ", " + db.group.Find(oS.id_class).classname;
            string invertory_number = oS.invertory_number.ToString();
            string service_start = oS.service_start.ToString();
            service_start = service_start.Substring(0, 10);

            string service_time = oS.service_time.ToString();

            List<pin> pinList = db.pin.Where(p => p.id_os == id).OrderBy(p => p.date).ToList();
            string mol = "";
            string pin_date = "";
            string unit = "";
            if (pinList.Count == 0)
            {
                mol = "не прикреплено";
                pin_date = "не прикреплено";
                unit = "не прикреплено";
            }
            else
            {
                pin pin1 = pinList[pinList.Count - 1];
                mol = pin1.id_mol.ToString() + ", " + db.MOL.Find(pin1.id_mol).molname;
                pin_date = pin1.date.ToString();
                pin_date = pin_date.Substring(0, 10);

                List<assigment> assigmentList = db.assigment.Where(a => a.id_mol == pin1.id_mol).ToList();
                if (assigmentList.Count == 0)
                {
                    unit = "МОЛ не назначен в отдел";
                }
                else 
                {
                    assigment assigment1 = assigmentList[assigmentList.Count - 1];
                    unit = assigment1.id_unit.ToString()+", "+db.unit.Find(assigment1.id_unit).unitname;
                }
            }

            string json = JsonConvert.SerializeObject(new requestCardOS { wearrate = wearrate, lastcost = lastcost, os_name = os_name,
                class1 = class1, invertory_number = invertory_number, service_start = service_start, service_time = service_time, 
                unit = unit, pin_date = pin_date, mol = mol });
            return json;
            
        }
    }
    [Serializable]
    public class requestCardOS
    {
        public string os_name { get; set; }
        public string class1 { get; set; }
        public string invertory_number { get; set; }
        public string wearrate { get; set; }
        public string service_start{ get; set; }
        public string service_time { get; set; }
        public string lastcost { get; set; }
        public string unit { get; set; }
        public string pin_date { get; set; }
        public string mol { get; set; }
    }
}

