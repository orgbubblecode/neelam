namespace OBSync.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newfields : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OBAPIResponses",
                c => new
                    {
                        obapiresponseid = c.Int(nullable: false, identity: true),
                        success = c.Boolean(nullable: false),
                        message = c.String(),
                        referenceID = c.String(),
                        callerIP = c.String(),
                        responseDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.obapiresponseid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OBAPIResponses");
        }
    }
}
