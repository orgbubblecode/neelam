namespace OBSync.Models.OBDataSources
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

    public partial class OBSyncOLTP : DbContext
    {

        public DbSet<OBAPIResponse> OBAPIResponses { get; set; }
        public DbSet<OBAPIEntitiesTracker> OBAPIEntitiesTrackers { get; set; }

        public OBSyncOLTP()
            : base("name=OBSyncOLTPConnection")
        {

            System.Data.Entity.Database.SetInitializer(new MigrateDatabaseToLatestVersion<OBSyncOLTP, OBSync.Models.Migrations.Configuration>());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<SrcDbContext, SRC.DomainModel.ORMapping.Migrations.Configuration>(useSuppliedContext: true));


        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


        }
    }
}
