using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OsAccountingApp1.Models
{
    public class WorkLoadReportModel
    {
        [DisplayName("ФИО")]
        public string molname { get; set; }
        [DisplayName("Дата рождения")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime birthday { get; set; }
        [DisplayName("Дата назначения")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime arrivaldateunit { get; set; }
        [DisplayName("Отдел")]
        public string unit { get; set; }
    }
}