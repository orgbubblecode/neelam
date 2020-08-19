using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;




namespace OBSync.Models.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<OBSync.Models.OBDataSources.OBSyncOLTP>
    {

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;


        }




    }
}