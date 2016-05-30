namespace Oleg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ddd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Outlays", "OutlayPrice", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Outlays", "OutlayPrice");
        }
    }
}
