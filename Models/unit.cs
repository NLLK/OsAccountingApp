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

    public partial class unit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public unit()
        {
            this.assigment = new HashSet<assigment>();
        }
        [DisplayName("Код отдела")]
        public int id_unit { get; set; }
        [DisplayName("Название отдела")]
        public string unitname { get; set; }
        [DisplayName("Адрес отдела")]
        public string adress { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<assigment> assigment { get; set; }
    }
}
