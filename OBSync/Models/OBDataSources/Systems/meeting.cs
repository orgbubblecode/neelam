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
    
    public partial class meeting
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
        public string location { get; set; }
        public string password { get; set; }
        public string join_url { get; set; }
        public string host_url { get; set; }
        public string displayed_url { get; set; }
        public string creator { get; set; }
        public string external_id { get; set; }
        public Nullable<int> duration_hours { get; set; }
        public Nullable<int> duration_minutes { get; set; }
        public Nullable<System.DateTime> date_start { get; set; }
        public Nullable<System.DateTime> date_end { get; set; }
        public string parent_type { get; set; }
        public string status { get; set; }
        public string type { get; set; }
        public Nullable<System.Guid> parent_id { get; set; }
        public Nullable<int> reminder_time { get; set; }
        public Nullable<int> email_reminder_time { get; set; }
        public Nullable<bool> email_reminder_sent { get; set; }
        public string outlook_id { get; set; }
        public Nullable<int> sequence { get; set; }
        public string repeat_type { get; set; }
        public Nullable<int> repeat_interval { get; set; }
        public string repeat_dow { get; set; }
        public Nullable<System.DateTime> repeat_until { get; set; }
        public Nullable<int> repeat_count { get; set; }
        public Nullable<System.Guid> repeat_parent_id { get; set; }
        public string recurring_source { get; set; }
        public string gsync_id { get; set; }
        public Nullable<int> gsync_lastsync { get; set; }
    }
}
