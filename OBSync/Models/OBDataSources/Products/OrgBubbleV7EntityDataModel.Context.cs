﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OBSync.Models.OBDataSources.Products
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class OBV7Entities : DbContext
    {
        public OBV7Entities()
            : base("name=OBV7Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sp_account_manager> sp_account_manager { get; set; }
        public virtual DbSet<sp_caption> sp_caption { get; set; }
        public virtual DbSet<sp_coupon_manager> sp_coupon_manager { get; set; }
        public virtual DbSet<sp_file_manager> sp_file_manager { get; set; }
        public virtual DbSet<sp_group_manager> sp_group_manager { get; set; }
        public virtual DbSet<sp_instagram_activities> sp_instagram_activities { get; set; }
        public virtual DbSet<sp_instagram_activities_log> sp_instagram_activities_log { get; set; }
        public virtual DbSet<sp_instagram_analytics> sp_instagram_analytics { get; set; }
        public virtual DbSet<sp_instagram_analytics_stats> sp_instagram_analytics_stats { get; set; }
        public virtual DbSet<sp_instagram_sessions> sp_instagram_sessions { get; set; }
        public virtual DbSet<sp_language> sp_language { get; set; }
        public virtual DbSet<sp_language_category> sp_language_category { get; set; }
        public virtual DbSet<sp_options> sp_options { get; set; }
        public virtual DbSet<sp_package_manager> sp_package_manager { get; set; }
        public virtual DbSet<sp_payment_history> sp_payment_history { get; set; }
        public virtual DbSet<sp_payment_subscriptions> sp_payment_subscriptions { get; set; }
        public virtual DbSet<sp_posts> sp_posts { get; set; }
        public virtual DbSet<sp_proxy_manager> sp_proxy_manager { get; set; }
        public virtual DbSet<sp_purchase_manager> sp_purchase_manager { get; set; }
        public virtual DbSet<sp_team> sp_team { get; set; }
        public virtual DbSet<sp_team_member> sp_team_member { get; set; }
        public virtual DbSet<sp_users> sp_users { get; set; }
        public virtual DbSet<sp_sessions> sp_sessions { get; set; }
    }
}
