namespace Oleg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OutLay : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Outlays",
                c => new
                    {
                        OutlayId = c.Int(nullable: false, identity: true),
                        OutlayTitle = c.String(nullable: false),
                        OutlayOrganization = c.String(nullable: false),
                        OutlayMan = c.String(nullable: false),
                        OutlayDate = c.DateTime(nullable: false),
                        OutlayContent = c.String(),
                        OutlayPhoto = c.String(),
                    })
                .PrimaryKey(t => t.OutlayId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Outlays");
        }
    }
}
