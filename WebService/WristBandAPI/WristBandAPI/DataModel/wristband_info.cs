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
    
    public partial class wristband_info
    {
        public long id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Nullable<short> status { get; set; }
        public Nullable<long> issued_to { get; set; }
        public Nullable<long> issued_by { get; set; }
        public Nullable<System.DateTime> issued_datetime { get; set; }
        public Nullable<short> is_delete { get; set; }
    
        public virtual user user { get; set; }
        public virtual user user1 { get; set; }
        public virtual xxbt_yesno xxbt_yesno { get; set; }
        public virtual xxbt_wb_status xxbt_wb_status { get; set; }
    }
}
