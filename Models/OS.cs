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

    public partial class OS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OS()
        {
            this.cost = new HashSet<cost>();
            this.pin = new HashSet<pin>();
        }
        [DisplayName("Код ОС")]
        public int id_os { get; set; }
        [DisplayName("Класс ОС")]
        public int id_class { get; set; }
        [DisplayName("Наименование ОС")]
        public string os_name { get; set; }
        [DisplayName("Инвертарный номер")]
        public string invertory_number { get; set; }
        [DisplayName("Норма износа")]
        public double wearrate { get; set; }
        [DisplayName("Дата начала обслуживания")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public System.DateTime service_start { get; set; }
        [DisplayName("Время обслуживания")]
        public int service_time { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cost> cost { get; set; }
        public virtual group group { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pin> pin { get; set; }
    }
}
