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
    
    public partial class assigment
    {
        [DisplayName("Код назначения")]
        public int id_assignment { get; set; }
        [DisplayName("Код сотрудника")]
        public int id_mol { get; set; }
        [DisplayName("Код отдела")]
        public int id_unit { get; set; }
        [DisplayName("Дата назначения")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime arrivaldateunit { get; set; }

        public virtual MOL MOL { get; set; }
        public virtual unit unit { get; set; }
    }
}
