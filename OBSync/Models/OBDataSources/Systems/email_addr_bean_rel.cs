//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OBSync.Models.OBDataSources.Systems
{
    using System;
    using System.Collections.Generic;
    
    public partial class email_addr_bean_rel
    {
        public System.Guid id { get; set; }
        public System.Guid email_address_id { get; set; }
        public System.Guid bean_id { get; set; }
        public string bean_module { get; set; }
        public Nullable<bool> primary_address { get; set; }
        public Nullable<bool> reply_to_address { get; set; }
        public Nullable<System.DateTime> date_created { get; set; }
        public Nullable<System.DateTime> date_modified { get; set; }
        public Nullable<bool> deleted { get; set; }
    }
}
