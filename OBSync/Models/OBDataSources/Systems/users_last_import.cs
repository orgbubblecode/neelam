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
    
    public partial class users_last_import
    {
        public System.Guid id { get; set; }
        public Nullable<System.Guid> assigned_user_id { get; set; }
        public string import_module { get; set; }
        public string bean_type { get; set; }
        public Nullable<System.Guid> bean_id { get; set; }
        public Nullable<bool> deleted { get; set; }
    }
}
