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
    
    public partial class payment
    {
        public long id { get; set; }
        public int user_id { get; set; }
        public Nullable<int> package_id { get; set; }
        public string processor { get; set; }
        public string type { get; set; }
        public string plan { get; set; }
        public string payment_id { get; set; }
        public string subscription_id { get; set; }
        public string payer_id { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public Nullable<float> amount { get; set; }
        public string currency { get; set; }
        public Nullable<System.DateTime> date { get; set; }
    
        public virtual package package { get; set; }
        public virtual user user { get; set; }
    }
}
