//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AllMyBio
{
    using System;
    using System.Collections.Generic;
    
    public partial class link
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public link()
        {
            this.track_links = new HashSet<track_links>();
        }
    
        public int link_id { get; set; }
        public int project_id { get; set; }
        public int user_id { get; set; }
        public Nullable<int> biolink_id { get; set; }
        public Nullable<int> domain_id { get; set; }
        public string type { get; set; }
        public string subtype { get; set; }
        public string url { get; set; }
        public string location_url { get; set; }
        public int clicks { get; set; }
        public string settings { get; set; }
        public int order { get; set; }
        public Nullable<System.DateTime> start_date { get; set; }
        public Nullable<System.DateTime> end_date { get; set; }
        public sbyte is_enabled { get; set; }
        public System.DateTime date { get; set; }
    
        public virtual project project { get; set; }
        public virtual user user { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<track_links> track_links { get; set; }
    }
}
