//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OsAccountingApp1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class pin
    {
        [DisplayName("Код прикрепления")]
        public int id_pin { get; set; }
        [DisplayName("Код МОЛ")]
        public int id_mol { get; set; }
        [DisplayName("Код ОС")]
        public int id_os { get; set; }
        [DisplayName("Дата прикрепления")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime date { get; set; }
    
        public virtual MOL MOL { get; set; }
        public virtual OS OS { get; set; }
    }
}
