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
    using OrgBubble;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class OrgBubbleDbEntities : DbContext
    {
        public OrgBubbleDbEntities()
            : base("name=OrgBubbleDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<facebook_accounts> facebook_accounts { get; set; }
        public virtual DbSet<facebook_posts> facebook_posts { get; set; }
        public virtual DbSet<general_caption> general_caption { get; set; }
        public virtual DbSet<general_coupons> general_coupons { get; set; }
        public virtual DbSet<general_custom_page> general_custom_page { get; set; }
        public virtual DbSet<general_file_manager> general_file_manager { get; set; }
        public virtual DbSet<general_groups> general_groups { get; set; }
        public virtual DbSet<general_lang> general_lang { get; set; }
        public virtual DbSet<general_lang_list> general_lang_list { get; set; }
        public virtual DbSet<general_options> general_options { get; set; }
        public virtual DbSet<general_packages> general_packages { get; set; }
        public virtual DbSet<general_payment_history> general_payment_history { get; set; }
        public virtual DbSet<general_payment_subscriptions> general_payment_subscriptions { get; set; }
        public virtual DbSet<general_proxies> general_proxies { get; set; }
        public virtual DbSet<general_purchase> general_purchase { get; set; }
        public virtual DbSet<general_users> general_users { get; set; }
        public virtual DbSet<instagram_accounts> instagram_accounts { get; set; }
        public virtual DbSet<instagram_activities> instagram_activities { get; set; }
        public virtual DbSet<instagram_activities_log> instagram_activities_log { get; set; }
        public virtual DbSet<instagram_analytics> instagram_analytics { get; set; }
        public virtual DbSet<instagram_analytics_stats> instagram_analytics_stats { get; set; }
        public virtual DbSet<instagram_posts> instagram_posts { get; set; }
        public virtual DbSet<instagram_sessions> instagram_sessions { get; set; }
        public virtual DbSet<linkedin_accounts> linkedin_accounts { get; set; }
        public virtual DbSet<linkedin_posts> linkedin_posts { get; set; }
        public virtual DbSet<pinterest_accounts> pinterest_accounts { get; set; }
        public virtual DbSet<pinterest_posts> pinterest_posts { get; set; }
        public virtual DbSet<twitter_accounts> twitter_accounts { get; set; }
        public virtual DbSet<twitter_posts> twitter_posts { get; set; }
        public virtual DbSet<general_sessions> general_sessions { get; set; }
    }
}
