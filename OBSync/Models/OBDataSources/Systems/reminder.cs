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
    
    public partial class reminder
    {
        public System.Guid id { get; set; }
        public string name { get; set; }
        public Nullable<System.DateTime> date_entered { get; set; }
        public Nullable<System.DateTime> date_modified { get; set; }
        public Nullable<System.Guid> modified_user_id { get; set; }
        public Nullable<System.Guid> created_by { get; set; }
        public string description { get; set; }
        public Nullable<bool> deleted { get; set; }
        public Nullable<System.Guid> assigned_user_id { get; set; }
        public Nullable<bool> popup { get; set; }
        public Nullable<bool> email { get; set; }
        public Nullable<bool> email_sent { get; set; }
        public string timer_popup { get; set; }
        public string timer_email { get; set; }
        public string related_event_module { get; set; }
        public System.Guid related_event_module_id { get; set; }
        public Nullable<int> date_willexecute { get; set; }
        public Nullable<bool> popup_viewed { get; set; }
    }
}
