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
    
    public partial class meetings_users
    {
        public string id { get; set; }
        public string meeting_id { get; set; }
        public string user_id { get; set; }
        public string required { get; set; }
        public string accept_status { get; set; }
        public Nullable<System.DateTime> date_modified { get; set; }
        public Nullable<bool> deleted { get; set; }
    }
}
