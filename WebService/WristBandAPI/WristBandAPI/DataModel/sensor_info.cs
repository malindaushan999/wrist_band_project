//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WristBandAPI.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class sensor_info
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sensor_info()
        {
            this.sensor_data = new HashSet<sensor_data>();
        }
    
        public long id { get; set; }
        public string name { get; set; }
        public string serial_no { get; set; }
        public string description { get; set; }
        public Nullable<short> sensor_type { get; set; }
        public Nullable<long> added_by { get; set; }
        public Nullable<System.DateTime> added_datetime { get; set; }
        public Nullable<long> modified_by { get; set; }
        public Nullable<System.DateTime> modified_datetime { get; set; }
        public Nullable<short> is_delete { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sensor_data> sensor_data { get; set; }
        public virtual xxbt_yesno xxbt_yesno { get; set; }
        public virtual xxbt_sensor_type xxbt_sensor_type { get; set; }
    }
}
